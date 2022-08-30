using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasParser : MonoBehaviour
{

    [SerializeField] Joystick _mainSteer;
    [SerializeField] Joystick _keelSteer;
    [SerializeField] Joystick _keelSteerUpDown;
    [SerializeField] Joystick _powerSteer;


    private void Update()
    {
        SimulationManager.Instance.MainSteer = _mainSteer.Horizontal;
        SimulationManager.Instance.KeelSteer = _keelSteer.Horizontal;
        SimulationManager.Instance.KeelSteerUpDown = _keelSteerUpDown.Vertical;
        SimulationManager.Instance.EnginePower = _powerSteer.Vertical;

    }
}
