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
        money = 500;
        tradeOffers = new List<TradeOfferInfo>();
        resourcesInfo = new Dictionary<Consts.ResourceType, int>();
        foreach (Consts.ResourceType type in Enum.GetValues(typeof(Consts.ResourceType)))
        {
            resourcesInfo.Add(type, 0);
        }
    }

    public void ResourceFromCells(Cell cell) {
        Debug.Log("test");
        if (!resourcesInfo.ContainsKey(cell.CellData.Resource))
        {
            resourcesInfo[cell.CellData.Resource] = 0;
        }

        resourcesInfo[cell.CellData.Resource] += cell.CurrentResourceCount;
        
    }
}

