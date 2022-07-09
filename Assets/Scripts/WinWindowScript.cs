using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWindowScript : BaseWindow
{
    public override void ButtonCloseOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        Application.Quit();
    }
}
