using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimConstatns
{
    private static float inputLongtide = 0;
    private static float inputLatitude = 0;
    private static float _height = 50;
    private static float _scale = 1;

    public static float InputLongtide { get => inputLongtide; set => inputLongtide = value; }
    public static float InputLatitude { get => inputLatitude; set => inputLatitude = value; }
    public static float Height { get => _height; set => _height = value; }
    public static float Scale { get => _scale; set => _scale = value; }

    public static Vector3 StartWorldPostion
    {
        get
        {
            var x = InputLatitude / Scale;
            var z = InputLongtide / Scale;
            var y = Height / Scale;
            return new Vector3(x, y, z);
        }
    }

}
