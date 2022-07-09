using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinWindowScript : BaseWindow
{
    [SerializeField] private TextMeshProUGUI MovesText;
    [SerializeField] private TextMeshProUGUI Nicknamw;

    protected override void Awake()
    {
        base.Awake();
        MovesText.text = "Moves: " + GameManager.Instance.PlayerData.turn.ToString();
    }

    public override void ButtonCloseOnClick()
    {
        GameManager.Instance.PlaySound("ButtonClick");
        if (Nicknamw.text == "") {
            Application.Quit(); 
        }
        GameJolt.API.Scores.Add(GameManager.Instance.PlayerData.turn, $"{GameManager.Instance.PlayerData.turn} turns", Nicknamw.text, 741470, "", (bool success) =>
        {
            Application.Quit();
        });
    }
}
