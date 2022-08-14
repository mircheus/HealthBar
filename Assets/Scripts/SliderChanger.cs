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
    [SerializeField] private int _smoothTime = 25;
    [SerializeField] private float _currentVelocity = 0f;
    
    private float _startValue;
    private Slider _slider;
    private float target;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.HealthPoints;
        _slider.value = _slider.maxValue;
        target = _slider.value;
    }
    
    private void Update()
    {
        target = _player.HealthPoints;
        float currentValue = Mathf.SmoothDamp(_slider.value, target, ref _currentVelocity, _smoothTime * Time.deltaTime);
        _slider.value = currentValue;
    }
}
