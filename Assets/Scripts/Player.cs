using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // public static Action onChanged;
    // public static event UnityAction Healed;
    // public static event UnityAction Damaged;
    public static event UnityAction Changed;

    // private Heal _healButton;
    // private Button _damageButton;
    // [SerializeField] private Button _healButton;
    // [SerializeField] private Button _damageButton;
    // [SerializeField] private UnityEvent _changed;
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
        _healthPoints = _healthPoints > _maxHealthPoints ? _maxHealthPoints : _healthPoints;
        Changed?.Invoke();
        // onChanged?.Invoke();
    }

    private void Damage()
    {
        _healthPoints -= _damagePoints;
        _healthPoints = _healthPoints < 0 ? 0 : _healthPoints;
        Changed?.Invoke();
        // onChanged?.Invoke();
    }
}
