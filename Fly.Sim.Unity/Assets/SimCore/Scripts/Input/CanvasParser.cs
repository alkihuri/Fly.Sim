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
        ParseDate();
    }
    private void LateUpdate()
    {
        VersaCanvasSync();
    }

    private void ParseDate()
    {
        SimulationManager.Instance.MainSteer = _mainSteer.Horizontal;
        SimulationManager.Instance.KeelSteer = _keelSteer.Horizontal;
        SimulationManager.Instance.KeelSteerUpDown = _keelSteerUpDown.Vertical;
        SimulationManager.Instance.EnginePower = _powerSteer.Vertical;
    }

   

    private void VersaCanvasSync()
    {
        _mainSteer.handle.anchoredPosition = new Vector2(SimulationManager.Instance.MainSteer * 128, 0);
        _keelSteer.handle.anchoredPosition = new Vector2(SimulationManager.Instance.KeelSteer * 128, 0);
        _keelSteerUpDown.handle.anchoredPosition = new Vector2(0, SimulationManager.Instance.KeelSteerUpDown * 128);
        _powerSteer.handle.anchoredPosition = new Vector2(0, SimulationManager.Instance.EnginePower * 128);
    }
}
