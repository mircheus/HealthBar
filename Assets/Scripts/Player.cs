using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _maxHealthPoints;
    [SerializeField] private float _healthPoints;

    private void Start()
    {
        _healthPoints = _maxHealthPoints;
    }

    private void Update()
    {
        _healthPoints = Mathf.Clamp(_healthPoints, 0, _maxHealthPoints);
    }

    public float HealthPoints => _healthPoints;
    
    public void Heal(float value)
    {
        _healthPoints += value;
    }

    public void Damage(float value)
    {
        _healthPoints -= value;
    }
}
