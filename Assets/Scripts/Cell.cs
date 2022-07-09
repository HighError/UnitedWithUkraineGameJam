using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CellData
{
    public Consts.CellType CellType;
    public Resource Resource;
    public int GoldPrice;
}

public class Cell
{
    public CellData CellData;
    public Vector3Int position;
    public int Level;
    public int CurrentResourceCount;

    public Cell(Vector3Int pos)
    {
        Level = 1;
        CurrentResourceCount = 0;
        this.position = pos;
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
