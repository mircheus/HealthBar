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
    // [SerializeField] private int _smoothTime = 25;
    // [SerializeField] private float _currentVelocity = 0f;


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
        // Debug.Log($"_slider.value = {_slider.value}");
    }

    public void SlideHP()
    {
        // _slider.value = _player.HealthPoints;
        // Debug.Log($"slider value = {_slider.value}");
        float target = _player.HealthPoints;
        // Debug.Log($"target = {target}");
        
        if (_changer != null)
        {
            StopCoroutine(_changer);
            Debug.Log($"Coroutine stopped");
        }
        
        _changer = StartCoroutine(MoveSlider(target));
        
    }

    private IEnumerator MoveSlider(float value)
    {
        var waitFor = new WaitForSeconds(0.01f);
        float delta = 1f;
        float currentVelocity = 0f;
        float smoothTime = 1f;
        float currentValue = _slider.value;
        
        Debug.Log($"Coroutine started");
        
        // while (Math.Abs(currentValue - target) > 0.000001f)
        // while (Math.Abs(_slider.value - target) > 0.1f)
        
        // РАБОЧИЙ ВАРИАНТ
        // while(currentValue != value)
        // {
        //     Debug.Log($"_slider.value = {_slider.value}");
        //     // _slider.value = Mathf.MoveTowards(_slider.value, value, delta);
        //     currentValue = Mathf.MoveTowards(currentValue, value, delta);
        //     _slider.value = currentValue;
        //     // _slider.value = Mathf.SmoothDamp(_slider.value, value, ref currentVelocity, smoothTime);
        //     yield return waitFor;
        // }
        
        
        while(Math.Abs(_slider.value - value) > 0.01f)
        {
            Debug.Log($"_slider.value = {_slider.value}");
            _slider.value = Mathf.MoveTowards(_slider.value, value, delta);
            yield return waitFor;
        }
    }
}
