using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]
public class SliderChanger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _slideDuration = 0.5f;
    
    private Slider _slider;
    private Coroutine _sliderCoroutine;

    private void OnEnable()
    {
        _player.Changed += MoveSlider;
    }

    private void OnDisable()
    {
        _player.Changed -= MoveSlider;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealthPoints;
        _slider.value = _player.CurrentHealthPoints;
    }

    // private void MoveSlider(int target)
    // {
    //     _slider.DOValue(target, _slideDuration);
    // }

    private void MoveSlider(int target)
    {
        if (_sliderCoroutine != null)
        {
            StopCoroutine(_sliderCoroutine);
        }
    
        _sliderCoroutine = StartCoroutine(SliderCoroutine(target));
    }
    
    private IEnumerator SliderCoroutine(int target)
    {
        const float seconds = 0.001f;
        var waitFor = new WaitForSeconds(seconds); 
        int slideDelta = 1; 

        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, slideDelta);
            yield return waitFor;
        }
    }
}
