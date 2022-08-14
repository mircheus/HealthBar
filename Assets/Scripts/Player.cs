using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _maxHealthPoints = 250;
    [SerializeField] private float _healthPoints;

    private void Start()
    {
        _healthPoints = _maxHealthPoints;
    }
    
    public float GetHealthPoints()
    {
        return _healthPoints;
    }

    public void IncreaseHealth(float value)
    {
        _healthPoints += value;

        if (_healthPoints > _maxHealthPoints)
        {
            _healthPoints = _maxHealthPoints;
        }
    }

    public void DecreaseHealth(float value)
    {
        _healthPoints -= value;

        if (_healthPoints < 0)
        {
            _healthPoints = 0;
        }
    }
}
