using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovesManager : MonoBehaviour
{
    private List<KeyValuePair<int, UnityAction>> callbacks;

    private void Awake()
    {
        callbacks = new List<KeyValuePair<int, UnityAction>>();
        GameManager.Instance.UIManager.UpdateUI();
    }

    public void NextMove()
    {
        GameManager.Instance.PlayerData.turn++;
        for (int i = 0; i < callbacks.Count; i++)
        {
            if (callbacks[i].Key == GameManager.Instance.PlayerData.turn)
            {
                callbacks[i].Value.Invoke();
                callbacks.RemoveAt(i);
                --i;
            }
        }

        if (GameManager.Instance.PlayerData.turn > 50)
        {
            GameManager.Instance.PlayerData.money = Mathf.Max(0, GameManager.Instance.PlayerData.money - 5);
        }

        GameManager.Instance.MapManager.cells.ForEach(cell => cell.NextMove());
        GameManager.Instance.UIManager.UpdateUI();

        GameManager.Instance.PlayerData.tradeOffers.Clear();
        for (int i = 0; i < UnityEngine.Random.Range(1, 4); i++)
        {
            CreateTradeOffer();
        }
    }

    public void AddCallback(int movesToWait, UnityAction callback)
    {
        callbacks.Add(new KeyValuePair<int, UnityAction>(GameManager.Instance.PlayerData.turn + movesToWait, callback));
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
        tradeOfferInfo.ResourceType = (Consts.ResourceType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Consts.ResourceType)).Length - 1);
        tradeOfferInfo.Price = (int)(GameManager.Instance.Cache.GetResource(tradeOfferInfo.ResourceType).GoldPrice * UnityEngine.Random.Range(0.8f, 1.2f));
        tradeOfferInfo.Amount = 1;
        GameManager.Instance.PlayerData.tradeOffers.Add(tradeOfferInfo);
    }
}
