using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class CustomFixedJoystick : FixedJoystick
{
    private Vector2 _startPosition;

    [SerializeField, Range(0, 100)] float _delay = 1;
    private Sequence seq;
    [SerializeField] bool stickStatic;

    private void Awake()
    {
        seq = DOTween.Sequence();
        freezeposition = true;
        _startPosition = handle.anchoredPosition;
    }


    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
    }
    public void Sync()
    {

        var clampedX = Mathf.Clamp(handle.anchoredPosition.x, -100, 100);
        var clampedY = Mathf.Clamp(handle.anchoredPosition.y, -100, 100);

        input = new Vector2(clampedX/100, clampedY/100);
        print("Sync!");
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (!stickStatic)
        {
            base.OnPointerUp(eventData);
            handle.DOAnchorPos(_startPosition, _delay).OnUpdate(Sync);
        }
    }


}
