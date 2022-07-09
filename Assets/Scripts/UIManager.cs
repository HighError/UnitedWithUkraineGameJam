using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI turns;
    [SerializeField] private GameObject notification;
    [SerializeField] private GameObject notificationPrefab;

    public void UpdateUI() { 
        money.text = $"{GameManager.Instance.PlayerData.money}$";
        turns.text = $"Turn: {GameManager.Instance.PlayerData.turn}";
    }

    public void CreateNotification(string text) { 
        GameObject not = Instantiate(notificationPrefab, notification.transform);
        not.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
    }

}
