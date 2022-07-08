using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class MapGenerator : MonoBehaviour
{
    public Tile[] tileBase;
    private Tilemap map;
    private System.Random rand = new System.Random();

    private void Start(){
        map = GetComponent<Tilemap>();


        for (int i = 0; i < 30; i++){
            for (int j = 0; j < 30; j++){
                int number = rand.Next() % tileBase.Length;
                map.SetTile(new Vector3Int(i,j,0), tileBase[number]);
            }
        }
    }
}
