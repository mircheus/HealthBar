using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    public static event UnityAction Pressed;
    private Button _healButton;

    private void Start()
    {
        _healButton = GetComponent<Button>();
        _healButton.onClick.AddListener(Pressed);
    }

    private void OnDisable()
    {
        _healButton.onClick.RemoveListener(Pressed);
    }
}
 