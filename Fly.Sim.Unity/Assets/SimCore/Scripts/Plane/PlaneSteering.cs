using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSteering : MonoBehaviour
{
    [SerializeField] Rigidbody _rBody;
    [SerializeField, Range(1, 5)] float SteerPower;
    [SerializeField] Transform _keel;


    private void Awake()
    {
        Cashing();
    }

    private void Cashing()
    {
        _rBody = GetComponentInParent<Rigidbody>();
    }

    public void DoLiftForce()
    {
        var liftCoefficient = _rBody.drag * _rBody.velocity.magnitude;
        Vector3 totalVector = transform.up * liftCoefficient + (Vector3.forward * liftCoefficient / 3);
        _rBody.AddRelativeForce(totalVector, ForceMode.Acceleration);
    }

    private void FixedUpdate()
    {
        DoLiftForce();
        DoManualSteer();
        DoKeelManualSteer();
    }

    private void DoManualSteer()
    {

        var keelSteerValue = SteerPower * -SimulationManager.Instance.MainSteer;
        _rBody.AddRelativeTorque(0, 0, keelSteerValue, ForceMode.Acceleration);
    }
    private void DoKeelManualSteer()
    {
        var keelSteerValue = SteerPower * SimulationManager.Instance.KeelSteer;
        var keelSteerValueUpDown = SteerPower * SimulationManager.Instance.KeelSteerUpDown;
        _rBody.AddRelativeTorque(keelSteerValueUpDown, keelSteerValue, 0, ForceMode.Acceleration);
    }
}
