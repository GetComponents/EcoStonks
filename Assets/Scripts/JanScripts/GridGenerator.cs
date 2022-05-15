using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;

    [SerializeField]
    Vector2 GridBoundries;


    [ContextMenu("Generate Grid")]
    void GenerateMap()
    {
        GameObject tileParent = Instantiate(new GameObject(), gameObject.transform);
        tileParent.transform.position = Vector3.zero;
        tileParent.name = "allTiles";
        for (int x = 0; x < GridBoundries.x; x++)
        {
            for (int y = 0; y < GridBoundries.y; y++)
            {
                GridTile tmp = Instantiate(tilePrefab, tileParent.transform).GetComponent<GridTile>();
                tmp.transform.position = new Vector3(x - (GridBoundries.x * 0.5f), 0, y - (GridBoundries.y * 0.5f)) * 10;
                tmp.MyPosition = new Vector3(x, 0, y);
            }
        }
    }

    [ContextMenu("UpdateTiles")]
    void UpdateTiles()
    {
        foreach (GridTile tile in FindObjectsOfType<GridTile>())
        {

            tile.MyTile = tile.MyTile;
        }
    }

}

public enum ETileType
{
    NONE,
    WOODS,
    EMPTY,
    WATER,
    CITY,
    COALPP,
    GASPP,
    WINDPP,
    SOLARPP,
    WATERPP,
    ATOMPP
}
