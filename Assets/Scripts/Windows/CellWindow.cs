using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellWindow : BaseWindow
{
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI ResourceStorageText;
    public TextMeshProUGUI LevelText;
    public Button UpgradeButton;
    public Image TitleImage;

    private Cell cell;

    public void SetCell(Cell cell)
    {
        this.cell = cell;
        ResetData();
    }

    private void ResetData()
    {
        TitleText.text = cell.CellData.Resource.ToString();
        LevelText.text = "Current Level: " + cell.Level.ToString();
        ResourceStorageText.text = cell.CellData.Resource.ToString() + ": " 
            + cell.CurrentResourceCount.ToString() + "/" + cell.GetStoreLimit().ToString();
        int cost = (cell.Level + 1) * cell.CellData.GoldPrice;
        if (cell.Level == 5)
        {
            UpgradeButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Max Level";
            UpgradeButton.interactable = false;
        }
        else {
            UpgradeButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = $"Upgrade: {cost}?";
            UpgradeButton.interactable = GameManager.Instance.PlayerData.money >= cost;
        }
    }

    public void Upgrade() {
        cell.Upgrade();
        ResetData();
    }
}
