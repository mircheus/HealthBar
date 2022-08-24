using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    public static event UnityAction Pressed;
    private Button _damageButton;

    private void Start()
    {
        _damageButton = GetComponent<Button>();
        _damageButton.onClick.AddListener(Pressed);
    }
    
    private void OnDisable()
    {
        _damageButton.onClick.RemoveListener(Pressed);
    }
}
