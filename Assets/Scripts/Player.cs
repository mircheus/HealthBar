using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static event UnityAction Changed;

    [SerializeField] private float _maxHealthPoints;
    [SerializeField] private float _healthPoints;
    [SerializeField] private int _healPoints;
    [SerializeField] private int _damagePoints;
    
    public float HealthPoints => _healthPoints;
    public float MaxHealthPoints => _maxHealthPoints;

    private void OnEnable()
    {
        HealButton.Pressed += Heal;
        DamageButton.Pressed += Damage;
    }

    private void OnDisable()
    {
        HealButton.Pressed -= Heal;
        DamageButton.Pressed -= Damage;
    }

    private void Heal()
    {
        _healthPoints += _healPoints;
        _healthPoints = Mathf.Clamp(_healthPoints, 0, _maxHealthPoints);
        Changed?.Invoke();
    }

    private void Damage()
    {
        _healthPoints -= _damagePoints;
        _healthPoints = Mathf.Clamp(_healthPoints, 0, _maxHealthPoints);
        Changed?.Invoke();
    }
}
