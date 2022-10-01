using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBoxJoystickIntegration : MonoBehaviour
{
    private void LateUpdate()
    {
        SimulationManager.Instance.MainSteer += Input.GetAxis("Horizontal_2");
        SimulationManager.Instance.KeelSteer += Input.GetAxis("Horizontal");
        SimulationManager.Instance.KeelSteerUpDown -= Input.GetAxis("Vertical");
        SimulationManager.Instance.EnginePower += Input.GetAxis("Vertical_2");

    }
}
