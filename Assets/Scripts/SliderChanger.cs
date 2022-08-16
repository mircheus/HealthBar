using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class SliderChanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _slideDuration = 0.5f;

    private Slider _slider;
    
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.HealthPoints;
        _slider.maxValue = _player.MaxHealthPoints;
    }

    public void MoveSlider()
    {
        float target = _player.HealthPoints;
        _slider.DOValue(target, _slideDuration);
    }
}
