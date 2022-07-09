using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerData : MonoBehaviour
{
    public Dictionary<Consts.ResourceType, int> resourcesInfo;

    public void ResourceFromCells(Cell cell) {
        Debug.Log("test");
        if (!resourcesInfo.ContainsKey(cell.CellData.Resource))
        {
            resourcesInfo[cell.CellData.Resource] = 0;
        }

        resourcesInfo[cell.CellData.Resource] += cell.CurrentResourceCount;
        
    }
}

