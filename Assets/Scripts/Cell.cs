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
        Level = 1;
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
        //TODO: create method
    }
}
