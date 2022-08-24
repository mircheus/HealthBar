using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
// 1. _damageButton = GetComponent<Button>(); При использовании GetComponent<>() мы должны гарантировать, что эти компоненты будут на объекте. Для этого используется RequireComponent (_healButton = GetComponent<Button>();) смысла в этих (HealButton, DamageButton) скриптах тут нету. 

// 2. public static event UnityAction<float> Changed; А зачем static. Просто public event нужен. 

// 3. private void OnEnable() { HealButton.Pressed += Heal; DamageButton.Pressed += Damage; } private void OnDisable() { HealButton.Pressed -= Heal; DamageButton.Pressed -= Damage; это соответственно не нужно. А private void Heal() private void Damage() Должны быть публичными, это главное взаимодействие игрока с внешним миром(его бьют или хилят) И Heal() и Damage() должны быть с параметрами величины наносимого им вреда/пользы (Heal(float heal)). 

// 4. В SliderChanger поле [SerializeField] private Player _player; как раз быть должно. У нас SliderChanger жить без Player не может. Соответственно зависимость от Player _player; должна быть. 

// 5. Очень хотел бы увидеть изменение _slider.DOValue(target, _slideDuration); через корунтину (не обязательно (пока что))

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
