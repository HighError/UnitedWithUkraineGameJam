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
    }

    public void AddCallback(int movesToWait, UnityAction callback)
    {
        callbacks.Add(new KeyValuePair<int, UnityAction>(currentMove + movesToWait, callback));
    }
}
