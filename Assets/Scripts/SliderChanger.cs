using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Player))]
public class SliderChanger : MonoBehaviour
{
    // [SerializeField] private float _delta = 0.1f;
    // [SerializeField] private float _deltaValue = 10f;
    [SerializeField] private Player _player;
    [SerializeField] private int _smoothTime = 25;
    [SerializeField] private float _currentVelocity = 0f;
    
    private float _startValue;
    private Slider _slider;
    // private float _currentValue;
    private float target;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.GetHealthPoints();
        // Debug.Log($"_startValue = {_startValue}" );
        _slider.value = _slider.maxValue;
        // Debug.Log($"_slider.value = {_slider.value}" );
        target = _slider.value;
        // Debug.Log($"target = {target}" );
    }

    // вариант через SmopthDamp
    private void Update()
    {
        target = _player.GetHealthPoints();
        float currentValue = Mathf.SmoothDamp(_slider.value, target, ref _currentVelocity, _smoothTime * Time.deltaTime);
        _slider.value = currentValue;
    }

    // Вариант через MoveTowards
    // private void Update()
    // {
    //     _currentValue = Mathf.MoveTowards(_slider.value, target, 0.1f);
    //     _slider.value = _currentValue;
    // }

    // public void Increment()
    // {
    //     target += _deltaValue;
    //
    //     if (target > _slider.maxValue)
    //     {
    //         target = _slider.maxValue;
    //     }
    // }

    // public void Increment()
    // {
    //     
    // }
    //
    //
    //
    // public void Decrement()
    // {
    //     target -= _deltaValue;
    //
    //     if (target < _slider.minValue)
    //     {
    //         target = _slider.minValue;
    //     }
    // }

    // private void BorderCheck()
    // {
    //     if (_currentValue > 100)
    //     {
    //         _currentValue = 100;
    //         _slider.value = 100;
    //     }
    //
    //     if (_currentValue < 0)
    //     {
    //         _currentValue = 0;
    //         _slider.value = 0;
    //     }
    // } 
}
