using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI turns;

    public void UpdateUI() { 
        money.text = $"{GameManager.Instance.PlayerData.money}$";
        turns.text = $"Turn: {GameManager.Instance.PlayerData.turn}";
    }

}
