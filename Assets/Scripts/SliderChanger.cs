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
    
    private Slider _slider;
    private float target;
    private Coroutine _changer;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _player.HealthPoints;
    }
    
    // public void MoveSlider()
    // {
    //     float target = _player.HealthPoints;
    //
    //     if (_changer != null)
    //     {
    //         StopCoroutine(_changer);
    //         Debug.Log($"Coroutine stopped");
    //     }
    //
    //     _changer = StartCoroutine(MoveSliderCoroutine(target));
    // }

    public void MoveSlider()
    {
        float target = _player.HealthPoints;
        DOTween.To(() => _slider.value, value => _slider.value = value, target, 0.5f);
    }

    private IEnumerator MoveSliderCoroutine(float value)
    {
        var waitFor = new WaitForSeconds(0.01f);
        float delta = 1f;
        float currentValue = _slider.value;
        
        // РАБОЧИЙ ВАРИАНТ
        while(currentValue != value)
        {
            Debug.Log($"_slider.value = {_slider.value}");
            currentValue = Mathf.MoveTowards(currentValue, value, delta);
            _slider.value = currentValue;
            yield return waitFor;
        }
    }
}
