using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Collections.Generic;
using System.Linq;

public class MapGenerator : MonoBehaviour
{

    public TileBase[] tiles;

    private Tilemap map;
    private System.Random rand = new System.Random();

    private void Start()
    {
        int tilesInOneCategory = tiles.Length / 4 ;
        map = GetComponent<Tilemap>();


        for (int i = 0; i < 20; i++){
            for (int j = 0; j < 20; j++){
                int number = rand.Next() % tiles.Length;
                map.SetTile(new Vector3Int(i,j,0), tiles[number]);
                Debug.Log(map.GetTile(new Vector3Int(i, j, 0)));
            }
        }
    }
}
