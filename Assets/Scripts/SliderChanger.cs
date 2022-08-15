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
    // private float _currentValue;
    private float target;
    private Coroutine _changer;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.HealthPoints;
        _slider.maxValue = _player.MaxHealthPoints;
    }

    public void MoveSlider()
    {
        float target = _player.HealthPoints;
        DOTween.To(() => _slider.value, value => _slider.value = value, target, 0.5f);
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
