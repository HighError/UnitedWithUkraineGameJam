using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Linq;

public class Map : MonoBehaviour
{
    public List<Cell> cells = new List<Cell>();
    public TileBase[] tiles;

    public Tilemap map { get; private set; }
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

    public Cell GetCell(Vector3Int pos) { 
        return cells.Where(e => e.Position == pos).FirstOrDefault();
    }
}