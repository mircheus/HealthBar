using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Slider _slider;

    public void OnPointerDown(PointerEventData eventData)
    {
        _slider.value += 0.1f;
    }
}
