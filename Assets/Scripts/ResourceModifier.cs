using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ResourceModifier
{
    public Consts.ResourceType ResourceType;
    public float CellPriceProcent;
    public int MiningTimeReduce;
}