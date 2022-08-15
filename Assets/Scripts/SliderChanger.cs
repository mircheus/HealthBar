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

    public void MoveSlider()
    {
        float target = _player.HealthPoints;
        DOTween.To(() => _slider.value, value => _slider.value = value, target, 0.5f);
    }
}
