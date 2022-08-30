using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityController : MonoBehaviour
{
    const float MAX_SPEED = 25;
    [SerializeField] Rigidbody _rBody;
    private float _speed;

    public float Speed { get => _speed; set => _speed = value; }
    public bool MaxSpeedReached { get; internal set; }
    public bool IsRedy { get; internal set; }

    private void Awake()
    {
        Cashing();
    }

    private void Cashing()
    {
        IsRedy = false;
        _rBody = GetComponentInParent<Rigidbody>();
        MaxSpeedReached = false;
    }

    private void Start()
    {
        IsRedy = true;
    }
    private void FixedUpdate()
    {
        _speed = _rBody.velocity.magnitude;
        NormalizeSpeed();
    }

    private void NormalizeSpeed()
    {
        MaxSpeedReached = _speed > MAX_SPEED;

        if (_speed > MAX_SPEED)
        {
            _rBody.velocity = _rBody.velocity.normalized * MAX_SPEED;
            
        } 
    }
}
