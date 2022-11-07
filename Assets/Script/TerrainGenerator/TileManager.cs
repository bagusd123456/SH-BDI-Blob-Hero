using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public int size;
    [SerializeField]
    private Tile[] tilePrefabs;
    [SerializeField]
    private PlayerMovement player;
    [SerializeField]
    private Vector2 tileSize = new Vector2(10, 10);
    private Vector3 oldTilePos = new Vector3(Mathf.Infinity, 0, Mathf.Infinity);
    private Dictionary<Vector2, Tile> spawnedTiles = new Dictionary<Vector2, Tile>();

    private void Start()
    {
        Tile newTile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length - 1)], new Vector3(0, 0, 0), Quaternion.identity);
        newTile.Init("0,0");
        spawnedTiles.Add(new Vector2(0, 0), newTile);
    }
    private void Update()
    {
        CalculateTiles();
    }

    public void CalculateTiles()
    {
        Vector3 tilePos = PlayerToTilePosition();
        int xPos = (int)tilePos.x;
        int zPos = (int)tilePos.z;
        if(new Vector3(xPos, 0, zPos) != oldTilePos)
        {
            oldTilePos = new Vector3(xPos, 0, zPos);
            CreateGrid(xPos, zPos);
        }
    }

    private Vector3 PlayerToTilePosition()
    {
        return new Vector3(Round(player.transform.position.x, tileSize.x), 0, Round(player.transform.position.z, tileSize.y));
    }

    private int Round(float value, float factor)
    {
        return (int)Mathf.Round(value / factor);
    }

    private void CreateGrid(int xPos, int zPos)
    {
        List<Vector2> newCoords = new List<Vector2>();
        for (int x = -size; x <= size; x++)
        {
            for (int z = -size; z <= size; z++)
            {
                newCoords.Add(new Vector2(xPos + x, zPos + z));
                if(!spawnedTiles.ContainsKey(new Vector2(xPos + x, zPos + z)))
                {
                    CreateTile(xPos + x, zPos + z);
                }
            }
        }
        RemoveTiles(newCoords);
    }

    private void RemoveTiles(List<Vector2> coords)
    {
        List<Vector2> toRemove = new List<Vector2>();
        foreach (var t in spawnedTiles.Keys)
        {
            if (!coords.Contains(t))
            {
                Tile tile = spawnedTiles[t];
                tile.Remove();
                toRemove.Add(t);
            }
        }
        foreach (var tP in toRemove)
        {
            spawnedTiles.Remove(tP);
        }
    }

    private void CreateTile(int xPos, int zPos)
    {
        Tile newTile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length - 1)], new Vector3((int)tileSize.x * xPos, 0, (int)tileSize.y * zPos), Quaternion.identity,transform);
        newTile.Init(string.Format("{0},{1}", new object[] { xPos, zPos }));
        spawnedTiles.Add(new Vector2(xPos, zPos), newTile);
    }
}
