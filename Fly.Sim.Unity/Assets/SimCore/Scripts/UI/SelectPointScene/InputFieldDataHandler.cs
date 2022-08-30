using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldDataHandler : MonoBehaviour, IFloatDataInput
{
    [SerializeField] TMP_InputField _inputField; 
    private void Awake() => _inputField = GetComponent<TMP_InputField>();
    public float GetData()
    {
        return System.Convert.ToSingle(_inputField.text);
    }


}
