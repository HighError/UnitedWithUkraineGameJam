using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
    public List<Cell> cells = new List<Cell>();
    public TileBase[] tiles;

    private Tilemap map;
    private System.Random rand = new System.Random();

    private void Start()
    {
        map = GetComponent<Tilemap>();
        GenerateWorld();
    }

    private void GenerateWorld() {
        int tilesInOneCategory = tiles.Length / 4;


        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                int number = rand.Next() % tiles.Length;
                Consts.CellType cellType = (Consts.CellType)(number / tilesInOneCategory);
                Vector3Int position = new Vector3Int(i, j, 0);

                map.SetTile(position, tiles[number]);
                cells.Add(new Cell(position));
            }
        }
    }
}