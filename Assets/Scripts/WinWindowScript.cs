using GameJolt.API;
using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinWindowScript : BaseWindow
{
    [SerializeField] private TextMeshProUGUI MovesText;
    [SerializeField] private TMP_InputField Nickname;

    [SerializeField] private Button LoginButton;
    [SerializeField] private Button SubmitButton;

    protected override void Awake()
    {
        if (!rectTransform)
            rectTransform = GetComponent<RectTransform>();
        ShowWindow();

        MovesText.text = "Moves: " + GameManager.Instance.PlayerData.turn.ToString();
        UpdateUI();
#if UNITY_WEBGL && !UNITY_EDITOR
        LoginButton.gameObject.SetActive(false);
#endif
    }

    private void UpdateUI()
    {
        Nickname.interactable = !GameJoltAPI.Instance.HasSignedInUser;
        if (GameJoltAPI.Instance.HasSignedInUser)
        {
            Nickname.text = GameJoltAPI.Instance.CurrentUser.Name;
        }
    }

    public void Login() {
        LoginButton.gameObject.SetActive(false);
        SubmitButton.gameObject.SetActive(false);
        if (GameJoltAPI.Instance.HasSignedInUser)
        {
            GameJoltAPI.Instance.CurrentUser.SignOut();
            UpdateUI();
            LoginButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Login";
        }
        else {
            GameJoltUI.Instance.ShowSignIn(null, (bool success) =>
            {
                UpdateUI();
                LoginButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Logout";
                LoginButton.gameObject.SetActive(true);
                SubmitButton.gameObject.SetActive(true);
            });
        }
        LoginButton.gameObject.SetActive(true);
        SubmitButton.gameObject.SetActive(true);
    }

    public void SubmitRecord()
    {
        int moves = GameManager.Instance.PlayerData.turn;
        GameManager.Instance.PlaySound("ButtonClick");
        bool isSignedIn = GameJoltAPI.Instance.HasSignedInUser;
        if (isSignedIn)
        {
            Scores.Add(moves, $"{moves} turns", callback: (bool success) =>
            {
                Application.Quit();
            });
        }
        else {
            Scores.Add(moves, $"{moves} turns", Nickname.text, callback: (bool success) =>
            {
                Application.Quit();
            });
        }
    }
}
