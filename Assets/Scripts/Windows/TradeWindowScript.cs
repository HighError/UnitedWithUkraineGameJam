using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeWindowScript : BaseWindow
{
    [SerializeField] private GameObject resourceInfoItemPrefab;
    [SerializeField] private GameObject tradeOffertemPrefab;
    [SerializeField] private RectTransform resourcesContainer;
    [SerializeField] private RectTransform tradeOffersContainer;

    private const int START_OFFSET_Y = 100;

    protected override void Awake()
    {
        base.Awake();

        int i = 0;
        foreach (var resourceInfo in GameManager.Instance.PlayerData.resourcesInfo)
        {
            if (resourceInfo.Value > 0)
            {
                ResourceInfoItemScript infoItem = Instantiate(resourceInfoItemPrefab, resourcesContainer).GetComponent<ResourceInfoItemScript>();
                infoItem.RectTransform.anchoredPosition3D = new Vector3(0, - START_OFFSET_Y - i * infoItem.RectTransform.sizeDelta.y);
                resourcesContainer.sizeDelta = new Vector2(resourcesContainer.sizeDelta.x, START_OFFSET_Y / 2 + (i + 1) * infoItem.RectTransform.sizeDelta.y);
                i++;
            }
        }
    }
}
