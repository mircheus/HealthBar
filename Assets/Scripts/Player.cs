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
    // [SerializeField] private UnityEvent _healed;
    // [SerializeField] private UnityEvent _damaged;
    [SerializeField] private UnityEvent _changed;
    
    // private void Start()
    // {
    //     Debug.Log($"HP on player = {_healthPoints}");
    // }

    private void Update()
    { 
        _healthPoints = Mathf.Clamp(_healthPoints, 0, _maxHealthPoints);
    }

    public float HealthPoints => _healthPoints;
    
    public void Heal(float value)
    {
        _healthPoints += value;
        // Debug.Log($"PLUS HP player = {HealthPoints}");
        _changed.Invoke();
        // _healed.Invoke();
    }

    public void Damage(float value)
    {
        _healthPoints -= value;
        // Debug.Log($"MINUS HP player = {HealthPoints}; delta = {value}");
        _changed.Invoke();
        // _damaged.Invoke();
    }
}
