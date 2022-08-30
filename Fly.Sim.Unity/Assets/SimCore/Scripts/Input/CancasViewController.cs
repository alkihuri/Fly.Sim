using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CancasViewController : MonoBehaviour
{
    [SerializeField] Transform _horizontalLine;
    [SerializeField] TextMeshProUGUI _heightText;

    [SerializeField, Range(0, 360)] float _currentZAngle;

    // Update is called once per frame
    void Update()
    {
        HorizontalLine();
        HeightHandler();
    }

    private void HeightHandler()
    {
        _heightText.text = SimulationManager.Instance.Height.ToString("#.");
    }

    private void HorizontalLine()
    {
        _currentZAngle = SimulationManager.Instance.HorizontalLine;

        if (_currentZAngle < 360 && _currentZAngle > 180)
            _currentZAngle -= 360;

        _currentZAngle = Mathf.Clamp(_currentZAngle, -90, 90);
        _horizontalLine.transform.localEulerAngles = new Vector3(0, 0, _currentZAngle);
    }
}
