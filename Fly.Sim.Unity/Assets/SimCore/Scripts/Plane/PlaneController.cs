using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private Transform _plane;
    private PlaneEngine _planeEngine;
    private VelocityController _vController;

    private void Awake()
    {
        Cashing();
    }
    private void Cashing()
    {
        _plane = transform.parent;
        _planeEngine = GetComponent<PlaneEngine>();
        _vController = GetComponent<VelocityController>();
    }

    private void Settings()
    {
        _plane.transform.position = SimConstatns.StartWorldPostion == null ? _plane.transform.position : SimConstatns.StartWorldPostion;
        StartCoroutine(StartForce());
    }

    private IEnumerator StartForce()
    {
        yield return new WaitWhile(() => !_vController.IsRedy);

        while (_vController.Speed < 10)
        {
            _planeEngine.ApplyForce(1000);
            yield return new WaitForFixedUpdate();
        }
    }

   

    // Start is called before the first frame update
    void Start()
    {
        Settings();
    }

}
