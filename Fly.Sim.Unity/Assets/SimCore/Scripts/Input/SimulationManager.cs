using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoSinglethon<SimulationManager>
{
    private float _mainSteer;
    private float _enginePower;
    private float _keelSteer;
    private float _keelSteerUpDown;
    private float _horizontalLine;
    private float _height;

    public float MainSteer { get => Mathf.Clamp(_mainSteer,-1,1); set => _mainSteer = value; }
    public float EnginePower { get => Mathf.Clamp(_enginePower, 0, 1); set => _enginePower = value; }
    public float KeelSteer { get => Mathf.Clamp(_keelSteer, -1, 1); set => _keelSteer = value; }
    public float KeelSteerUpDown { get => Mathf.Clamp(_keelSteerUpDown, -1, 1); set => _keelSteerUpDown = value; }
    public float HorizontalLine { get => _horizontalLine; set => _horizontalLine = value; }
    public float Height { get => _height; set => _height = value; }
}
