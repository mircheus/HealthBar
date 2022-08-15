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
    
    private void Update()
    { 
        _healthPoints = Mathf.Clamp(_healthPoints, 0, _maxHealthPoints);
    }

    public float HealthPoints => _healthPoints;
    public float MaxHealthPoints => _maxHealthPoints;
    
    public void Heal(float value)
    {
        _healthPoints += value;
        _changed.Invoke();
    }

    public void Damage(float value)
    {
        _healthPoints -= value;
        _changed.Invoke();
    }
}
