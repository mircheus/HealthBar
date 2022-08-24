using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public event UnityAction<int> Changed;

    [SerializeField] private int _maxHealthPoints;
    [SerializeField] private int _currentHealthPoints;

    public int CurrentHealthPoints => _currentHealthPoints;
    public int MaxHealthPoints => _maxHealthPoints;

    public void Heal(int healPoints)
    {
        _currentHealthPoints += healPoints;
        _currentHealthPoints = Mathf.Clamp(_currentHealthPoints, 0, _maxHealthPoints);
        Changed?.Invoke(_currentHealthPoints);
    }

    public void Damage(int damagePoints)
    {
        _currentHealthPoints -= damagePoints;
        _currentHealthPoints = Mathf.Clamp(_currentHealthPoints, 0, _maxHealthPoints);
        Changed?.Invoke(_currentHealthPoints);
    }
}
