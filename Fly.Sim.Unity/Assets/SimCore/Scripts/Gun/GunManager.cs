using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunManager : MonoBehaviour
{
    public UnityEvent OnAttack = new UnityEvent();
    public void Attack() => OnAttack.Invoke();

    private void FixedUpdate()
    {
        if (Input.GetAxis("Jump") > 0)
            Attack();
    }
}
