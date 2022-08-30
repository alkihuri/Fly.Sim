using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicStatesController : MonoBehaviour
{
    private Transform _plane;
    [SerializeField] private float _height;
    private RaycastHit _ground;

    private void Awake()
    {
        Cashing();
    }
    private void Cashing()
    {
        _plane = transform.parent; 
    }

    private void FixedUpdate()
    {
        HorizontalLine();
        Height();
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
