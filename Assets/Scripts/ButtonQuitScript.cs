using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuitScript : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(ButtonQuitOnClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveAllListeners();
    }

    private void ButtonQuitOnClick()
    {
        GameManager.Instance.InstantiateWindow("ExitWindow");
    }
}
