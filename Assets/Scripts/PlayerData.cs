using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData : MonoBehaviour
{
    public Dictionary<Consts.ResourceType, int> resourcesInfo;
    public List<TradeOfferInfo> tradeOffers;
    public int money;
    public int turn;

    private void Awake()
    {
        money = 100000;
        tradeOffers = new List<TradeOfferInfo>();
        resourcesInfo = new Dictionary<Consts.ResourceType, int>();
        foreach (Consts.ResourceType type in Enum.GetValues(typeof(Consts.ResourceType)))
        {
            resourcesInfo.Add(type, 999);
        }
    }

    public void ResourceFromCells(Consts.ResourceType resourceType, int count) {
        resourcesInfo[resourceType] += count;
        
    }
}

