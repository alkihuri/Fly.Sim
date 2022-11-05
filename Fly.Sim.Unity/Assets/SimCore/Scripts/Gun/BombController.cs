using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidBody;
    private Vector3 _target;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    internal void SetTarget(Vector3 target)
    {
        _target = target;
    }

    internal void Attack()
    {
        transform.SetParent(null);
        _rigidBody.isKinematic = false;
        StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        _rigidBody.AddForce((_target - transform.position).normalized * 3000, ForceMode.Impulse);
        while (Vector3.Distance(_target,transform.position) > 1)
        {
            _rigidBody.AddForce((_target - transform.position).normalized * 200, ForceMode.Acceleration);
            yield return new WaitForFixedUpdate();
        }
        AudioManager.Instance.PlayExplosion();
        Destroy(gameObject);
    }
}
