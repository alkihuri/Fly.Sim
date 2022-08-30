using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputDataController : MonoBehaviour
{

    public UnityEvent OnDatParse = new UnityEvent();
    [SerializeField] GameObject _latitudeGameObject;
    [SerializeField] GameObject _longtitudeGameObject;
    [SerializeField] GameObject _heightGameObject;
    IFloatDataInput _latitude;
    IFloatDataInput _longtitude;
    IFloatDataInput _height;

    private void Awake()
    {
        Cashing();
    }

    private void Cashing()
    {
        _latitude = _latitudeGameObject.GetComponent<IFloatDataInput>();
        _longtitude = _longtitudeGameObject.GetComponent<IFloatDataInput>();
        _height = _heightGameObject.GetComponent<IFloatDataInput>();
    }

    public void ParseData()
    {
        var longtide = _longtitude.GetData();
        var latitude = _latitude.GetData();
        var heght = _height.GetData();

        SimConstatns.Scale = 10;
        SimConstatns.InputLatitude = Mathf.Clamp(latitude, -100, 100);
        SimConstatns.InputLongtide = Mathf.Clamp(longtide, -100, 100);
        SimConstatns.Height = heght;

        OnDatParse.Invoke();
    }
}
