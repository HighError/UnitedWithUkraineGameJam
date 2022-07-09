using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeOfferItemScript : MonoBehaviour
{
    public TradeOfferInfo tradeOfferInfo;

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

    public void UpdateUI() {
        CountText.text = tradeOfferInfo.Amount.ToString();
        NationText.text = tradeOfferInfo.NationName;
        PriceText.text = $"{tradeOfferInfo.Price}$";
        foreach (var item in GameManager.Instance.Cache.GetCellDataList())
        {
            if (item.Resource == tradeOfferInfo.ResourceType)
            {
                ResourceIcon.sprite = item.Image;
                break;
            }
        }
        SellButton.interactable = GameManager.Instance.PlayerData.resourcesInfo[tradeOfferInfo.ResourceType] > 0;
    }

    private void OnDestroy()
    {
        SellButton.onClick.RemoveAllListeners();
    }

    private void SellButtonOnClick()
    {
        GameManager.Instance.PlayerData.money += tradeOfferInfo.Price;
        GameManager.Instance.PlayerData.resourcesInfo[tradeOfferInfo.ResourceType] -= 1;
        UpdateUI();
        GameManager.Instance.UIManager.UpdateUI();
    }
}
