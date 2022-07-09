using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovesManager : MonoBehaviour
{
    private List<KeyValuePair<int, UnityAction>> callbacks;
    private int currentMove;

    private void Awake()
    {
        currentMove = 1;
        callbacks = new List<KeyValuePair<int, UnityAction>>();
        GameManager.Instance.UIManager.UpdateUI();
    }

    public void NextMove()
    {
        for (int i = 0; i < callbacks.Count; i++)
        {
            if (callbacks[i].Key == currentMove)
            {
                callbacks[i].Value.Invoke();
                callbacks.RemoveAt(i);
                --i;
            }
        }

        GameManager.Instance.MapManager.cells.ForEach(cell => cell.NextMove());
        GameManager.Instance.PlayerData.turn++;
        GameManager.Instance.UIManager.UpdateUI();

        GameManager.Instance.PlayerData.tradeOffers.Clear();
        for (int i = 0; i < UnityEngine.Random.Range(1, 3); i++)
        {
            CreateTradeOffer();
        }
    }

    public void AddCallback(int movesToWait, UnityAction callback)
    {
        callbacks.Add(new KeyValuePair<int, UnityAction>(currentMove + movesToWait, callback));
    }

    private void CreateTradeOffer()
    {
        TradeOfferInfo tradeOfferInfo = new TradeOfferInfo();
        var nations = GameManager.Instance.Cache.GetNations();
        int nationIndex = UnityEngine.Random.Range(0, nations.Count - 1);
        int i = 0;
        foreach (var item in nations)
        {
            if (i == nationIndex)
            {
                tradeOfferInfo.NationName = item.Key;
                break;
            }
            i++;
        }
        tradeOfferInfo.resourceType = (Consts.ResourceType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Consts.ResourceType)).Length - 1);
        tradeOfferInfo.Price = (int)(GameManager.Instance.Cache.GetResource(tradeOfferInfo.resourceType).GoldPrice * UnityEngine.Random.Range(0.8f, 1.2f));
        GameManager.Instance.PlayerData.tradeOffers.Add(tradeOfferInfo);
    }
}
