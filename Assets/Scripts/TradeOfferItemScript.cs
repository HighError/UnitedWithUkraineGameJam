using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeOfferItemScript : MonoBehaviour
{
    public RectTransform RectTransform;
    public Image ResourceIcon;
    public TextMeshProUGUI NationText;
    public TextMeshProUGUI CountText;
    public TextMeshProUGUI PriceText;

    public Button SellButton;

    private void Awake()
    {
        SellButton.onClick.AddListener(SellButtonOnClick);
    }

    private void OnDestroy()
    {
        SellButton.onClick.RemoveAllListeners();
    }

    private void SellButtonOnClick()
    {
        //TODO:: create method
    }
}
