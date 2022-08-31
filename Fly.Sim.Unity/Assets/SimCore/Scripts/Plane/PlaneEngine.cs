using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlaneEngine : MonoBehaviour
{
    [SerializeField] Rigidbody _rBody;
    [SerializeField, Range(1, 59)] float EnginePower;
    private void Awake()
    {
        Cashing();
    }

    private void Cashing()
    {
        _rBody = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        DoEngine();
    }

    private void DoEngine()
    {
        var engineValue = Mathf.Lerp(0,20, SimulationManager.Instance.EnginePower) * EnginePower;
        ApplyForce(engineValue);
    }

    public void ApplyForce(float force)
    {
        _rBody.AddRelativeForce(Vector3.forward * force, ForceMode.Acceleration);
    }

}
