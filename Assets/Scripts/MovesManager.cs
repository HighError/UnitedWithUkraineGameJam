using System.Collections;
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
    }

    public void AddCallback(int movesToWait, UnityAction callback)
    {
        callbacks.Add(new KeyValuePair<int, UnityAction>(currentMove + movesToWait, callback));
    }
}
