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
        StartSettings();
    }

    private void StartSettings()
    {

        _plane.transform.position = SimConstatns.StartWorldPostion == null ? _plane.transform.position : SimConstatns.StartWorldPostion;
        
        
        var x = transform.transform.eulerAngles.x;
        var z = transform.transform.eulerAngles.z;
        _plane.transform.LookAt(Vector3.zero);
        var y = transform.transform.eulerAngles.y;
        _plane.transform.eulerAngles = new Vector3(x, y, z);
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
