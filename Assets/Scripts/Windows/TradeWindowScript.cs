using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeWindowScript : BaseWindow
{
    [SerializeField] private GameObject resourceInfoItemPrefab;
    [SerializeField] private GameObject tradeOfferItemPrefab;
    [SerializeField] private RectTransform resourcesContainer;
    [SerializeField] private RectTransform tradeOffersContainer;

    private const int START_OFFSET_Y_RESOURCES = 100;
    private const int START_OFFSET_Y_TRADE_OFFERS = 175;

    protected override void Awake()
    {
        base.Awake();

        EventSystem.OnUpdateTradeWindowResourcesUINeeded += UpdateTradeWindowResourcesUI;

        int i = 0;
        foreach (var resourceInfo in GameManager.Instance.PlayerData.resourcesInfo)
        {
            if (resourceInfo.Value >= 0 && resourceInfo.Key != Consts.ResourceType.None)
            {
                ResourceInfoItemScript infoItem = Instantiate(resourceInfoItemPrefab, resourcesContainer).GetComponent<ResourceInfoItemScript>();
                infoItem.RectTransform.anchoredPosition3D = new Vector3(0, -START_OFFSET_Y_RESOURCES - i * infoItem.RectTransform.sizeDelta.y);
                resourcesContainer.sizeDelta = new Vector2(resourcesContainer.sizeDelta.x, START_OFFSET_Y_RESOURCES / 2 + (i + 1) * infoItem.RectTransform.sizeDelta.y);
                i++;

                infoItem.ResourceType = resourceInfo.Key;
                infoItem.CountText.text = resourceInfo.Key.ToString() + ": " + resourceInfo.Value.ToString();
                foreach (var item in GameManager.Instance.Cache.GetCellDataList())
                {
                    if (item.Resource == resourceInfo.Key)
                    {
                        infoItem.Icon.sprite = item.Image;
                        break;
                    }
                } 
            }
        }
        i = 0;
        foreach (var tradeOfferInfo in GameManager.Instance.PlayerData.tradeOffers)
        {
            TradeOfferItemScript infoItem = Instantiate(tradeOfferItemPrefab, tradeOffersContainer).GetComponent<TradeOfferItemScript>();
            infoItem.RectTransform.anchoredPosition3D = new Vector3(0, -START_OFFSET_Y_TRADE_OFFERS - i * infoItem.RectTransform.sizeDelta.y);
            tradeOffersContainer.sizeDelta = new Vector2(tradeOffersContainer.sizeDelta.x, START_OFFSET_Y_TRADE_OFFERS / 2 + (i + 1) * infoItem.RectTransform.sizeDelta.y);
            i++;


            infoItem.tradeOfferInfo = tradeOfferInfo;
            infoItem.UpdateUI();
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        EventSystem.OnUpdateTradeWindowResourcesUINeeded -= UpdateTradeWindowResourcesUI;
    }

    void UpdateTradeWindowResourcesUI()
    {
        foreach (var infoItem in resourcesContainer.GetComponentsInChildren<ResourceInfoItemScript>())
        {
            infoItem.CountText.text = infoItem.ResourceType.ToString() + ": " + GameManager.Instance.PlayerData.resourcesInfo[infoItem.ResourceType].ToString();
        }
    }
}
