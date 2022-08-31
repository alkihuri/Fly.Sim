using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicStatesController : MonoBehaviour
{
    private Transform _plane;
    private VelocityController _vController;
    private Rigidbody _rBody;
    private PlaneEngine _planeEngine;
    [SerializeField] private float _height;
    private RaycastHit _ground;

    private void Awake()
    {
        Cashing();
    }
    private void Cashing()
    {
        _plane = transform.parent;
        _vController = GetComponent<VelocityController>();
        _planeEngine = GetComponent<PlaneEngine>();
        _rBody = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HorizontalLine();
        Height();
        WingEffect();
    }

    private void WingEffect()
    {
        _planeEngine.ApplyForce(_vController.Speed);
        _rBody.AddRelativeForce(Vector3.down * _vController.Speed, ForceMode.Acceleration);
    }

    private void Height()
    {
        if(Physics.Raycast(_plane.transform.position,Vector3.down,out _ground))
        {
            _height = _ground.distance;
            SimulationManager.Instance.Height = _height;
        }
    }

    private void HorizontalLine()
    {
        SimulationManager.Instance.HorizontalLine = _plane.transform.localEulerAngles.z;
    }
}
