using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Resource
{
    public Consts.ResourceType Type;
    public Consts.ResourceType BaseResource; //need base resource to produce resource

    public int Moves;
    public int Count;
    public int BaseResourceSpend;
    public int GoldPrice;
}