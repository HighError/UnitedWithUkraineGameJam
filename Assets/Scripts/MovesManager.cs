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
        currentMove = 0;
        callbacks = new List<KeyValuePair<int, UnityAction>>();
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
    }

    public void AddCallback(int movesToWait, UnityAction callback)
    {
        callbacks.Add(new KeyValuePair<int, UnityAction>(currentMove + movesToWait, callback));
    }
}
