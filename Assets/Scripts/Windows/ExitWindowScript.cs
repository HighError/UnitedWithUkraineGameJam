using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitWindowScript : BaseWindow
{
    public Button ButtonYes;

    protected override void Awake()
    {
        base.Awake();
        ButtonYes.onClick.AddListener(ButtonYesOnClick);
    }

    public void ButtonYesOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        Application.Quit();
    }
}
