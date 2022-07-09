using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeWindowScript : BaseWindow
{
    [SerializeField] private GameObject resourceInfoItemPrefab;
    [SerializeField] private GameObject tradeOfferItemPrefab;
    [SerializeField] private RectTransform resourcesContainer;
    [SerializeField] private RectTransform tradeOffersContainer;

    private const int START_OFFSET_Y = 100;

    protected override void Awake()
    {
        base.Awake();

        int i = 0;
        foreach (var resourceInfo in GameManager.Instance.PlayerData.resourcesInfo)
        {
            if (resourceInfo.Value >= 0 && resourceInfo.Key != Consts.ResourceType.None)
            {
                ResourceInfoItemScript infoItem = Instantiate(resourceInfoItemPrefab, resourcesContainer).GetComponent<ResourceInfoItemScript>();
                infoItem.RectTransform.anchoredPosition3D = new Vector3(0, - START_OFFSET_Y - i * infoItem.RectTransform.sizeDelta.y);
                resourcesContainer.sizeDelta = new Vector2(resourcesContainer.sizeDelta.x, START_OFFSET_Y / 2 + (i + 1) * infoItem.RectTransform.sizeDelta.y);
                i++;

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
            infoItem.RectTransform.anchoredPosition3D = new Vector3(0, -START_OFFSET_Y - i * infoItem.RectTransform.sizeDelta.y);
            tradeOffersContainer.sizeDelta = new Vector2(tradeOffersContainer.sizeDelta.x, START_OFFSET_Y / 2 + (i + 1) * infoItem.RectTransform.sizeDelta.y);
            i++;

            infoItem.CountText.text = tradeOfferInfo.Amount.ToString();
            infoItem.PriceText.text = tradeOfferInfo.Price.ToString();
            foreach (var item in GameManager.Instance.Cache.GetCellDataList())
            {
                if (item.Resource == tradeOfferInfo.resourceType)
                {
                    infoItem.ResourceIcon.sprite = item.Image;
                    break;
                }
            }
        }
    }
}
