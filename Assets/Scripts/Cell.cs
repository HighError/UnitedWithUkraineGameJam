using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public struct CellData
{
    public Consts.CellType CellType;
    public Consts.ResourceType Resource;
    public Sprite Image;
    public Tile TileResource;
    public int GoldPrice;
}

public class Cell
{
    public CellData CellData;
    public Vector3Int Position;
    public int Level;
    public int CurrentResourceCount;

    public Cell(Vector3Int pos, CellData cellData)
    {
        Level = 0;
        CurrentResourceCount = 0;
        this.Position = pos;
        this.CellData = cellData;
    }

    public int GetStoreLimit()
    {
        return Level * Consts.STORE_COUNT_FOR_LEVEL;
    }

    public void MoveToCity()
    {
        int distance = (int)Mathf.Sqrt(Vector3.Distance(Vector3.zero, this.Position));
        GameManager.Instance.MovesManager.AddCallback(distance, () => GameManager.Instance.PlayerData.ResourceFromCells(this));
    }

    public void NextMove() {
        int number = Random.Range(0, 3);
        if (number % 3 == 0 && CurrentResourceCount < GetStoreLimit()) {
            CurrentResourceCount++;
        }
    }

    public void Upgrade() {
        if (Level < 5) {
            Level++;
            GameManager.Instance.PlayerData.money -= Level * CellData.GoldPrice;
            GameManager.Instance.UIManager.UpdateUI();
        }
    }
}
