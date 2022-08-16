using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealthPoints;
    [SerializeField] private float _healthPoints;
    [SerializeField] private UnityEvent _changed;
    
    public float HealthPoints => _healthPoints;
    public float MaxHealthPoints => _maxHealthPoints;
    
    public void Heal(float value)
    {
        _healthPoints += value;
        _healthPoints = _healthPoints > _maxHealthPoints ? _maxHealthPoints : _healthPoints;
        _changed.Invoke();
    }

    public void Damage(float value)
    {
        _healthPoints -= value;
        _healthPoints = _healthPoints < 0 ? 0 : _healthPoints;
        _changed.Invoke();
    }
}
