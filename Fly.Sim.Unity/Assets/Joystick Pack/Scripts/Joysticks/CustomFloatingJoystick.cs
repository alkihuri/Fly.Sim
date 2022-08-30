using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomFloatingJoystick : FloatingJoystick
{
    private void Awake()
    {
        freezeposition = true;
    }

    [SerializeField]
    public UnityEvent OnJoystickReleased = new UnityEvent();
    Vector2 buffer = Vector2.zero;

    public override void OnPointerDown(PointerEventData eventData)
    {
        StopCoroutine(DelayStickShift());

        base.OnPointerDown(eventData);

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        OnJoystickReleased?.Invoke();

        buffer = new Vector2(Horizontal, 0);
        StartCoroutine(DelayStickShift());
        //background.gameObject.SetActive(false);
    }
     

    IEnumerator DelayStickShift()
    {
        float bufferHold = Mathf.Abs(buffer.x);
        float direction = -Horizontal;
        Vector2 radius = background.sizeDelta / 2;

        while (Mathf.Abs(buffer.x) > 0 && direction * buffer.x < 0)
        {
            yield return new WaitForSeconds(0.01f);
            var xPos = Mathf.Clamp(direction / 25, -1, 1);
            buffer += new Vector2(xPos, 0);
            input = buffer;
            handle.anchoredPosition = input * radius * handleRange;
        }
         
    }
}
