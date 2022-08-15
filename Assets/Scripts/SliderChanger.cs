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
    private Coroutine _changer;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.HealthPoints;
        // Debug.Log($"Start HP slider = {_slider.value}");
        // Debug.Log($"Start HP player = {_player.HealthPoints}");
        // Debug.Log($"HP on slider = {_player.HealthPoints}");
        // _slider.value = _slider.maxValue;
        // target = _slider.value;
    }
    
    private void Update()
    {
        // target = _player.HealthPoints;
        // float currentValue = Mathf.SmoothDamp(_slider.value, target, ref _currentVelocity, _smoothTime * Time.deltaTime);
        // float currentValue = Mathf.MoveTowards(_slider.value, target, 1f);
        // _slider.value = currentValue;
    }

    // public void SetPosition(float value)
    // {
    //     // target = _player.HealthPoints;
    //     // float currentValue = Mathf.MoveTowards(_slider.value, target, 1f);
    //     // _slider.value = currentValue;
    //     // _slider.value = value;
    // }


    public void SlideHP()
    {
        _slider.value = _player.HealthPoints;
        // Debug.Log($"slider value = {_slider.value}");
    }
    
    
    // public void IncreaseHealthBar(float value)
    // {
    //     if (_changer != null)
    //     {
    //         StopCoroutine(_changer);
    //     }
    //
    //     _slider.value += value;
    //     // _changer = StartCoroutine(MoveSlider(value));
    // }
    //
    // public void DecreaseHealthBar(float value)
    // {
    //     if (_changer != null)
    //     {
    //         StopCoroutine(_changer);
    //     }
    //
    //     _slider.value -= value;
    //     // _changer = StartCoroutine(MoveSlider(value));
    // }

    private IEnumerator MoveSlider(float value)
    {
        var waitFor = new WaitForSeconds(0.1f);
        float delta = 5f;
        float target = _slider.value + value;
        var i = 0;
        float currentVelocity = 0f;
        float smoothTime = 5f;
        
        // while (Math.Abs(_slider.value - target) > 0.1f)
        while (_slider.value != target)
        {
            Debug.Log(i);
            _slider.value = Mathf.MoveTowards(_slider.value, target, delta);
            // _slider.value = Mathf.SmoothDamp(_slider.value, target, ref currentVelocity, smoothTime);
            i++;
            yield return waitFor;
        }
    }
}
