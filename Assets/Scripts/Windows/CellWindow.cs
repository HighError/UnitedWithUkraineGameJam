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

    void SetCell(Cell cell)
    {
        this.cell = cell;
    }

    void ResetData()
    {
        TitleText.text = cell.CellData.Resource.ToString();
        LevelText.text = "Current Level: " + cell.Level.ToString();
        ResourceStorageText.text = cell.CellData.Resource.ToString() + ": " 
            + cell.CurrentResourceCount.ToString() + "/" + cell.GetStoreLimit().ToString();
    }
}
