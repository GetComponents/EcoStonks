using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridTile : MonoBehaviour
{
    [SerializeField]
    MeshRenderer myMesh;
    public ETileType MyTile
    {
        get => m_myTile;
        set
        {
            if (value != m_myTile)
            {
            }
            ReplaceMe(value);
            m_myTile = value;
        }
    }
    [SerializeField]
    private ETileType m_myTile;
    public Vector3 MyPosition;

    private void Start()
    {
        name = $"{MyPosition.x} / {MyPosition.z}";
    }

    [ContextMenu("ClickMe")]
    public void OnClickMe()
    {
        Debug.Log("I got Clicked");
    }

    [ExecuteInEditMode]
    public void ReplaceMe(ETileType newTile)
    {
        switch (newTile)
        {
            case ETileType.NONE:
                break;
            case ETileType.WOODS:
                myMesh.material.color = Color.green;
                break;
            case ETileType.EMPTY:
                myMesh.material.color = Color.white;
                break;
            case ETileType.WATER:
                myMesh.material.color = Color.blue;
                break;
            case ETileType.CITY:
                myMesh.material.color = Color.gray;
                break;
            case ETileType.COALPP:
                myMesh.material.color = Color.black;
                break;
            case ETileType.GASPP:
                myMesh.material.color = Color.yellow;
                break;
            case ETileType.WINDPP:
                myMesh.material.color = Color.cyan;
                break;
            case ETileType.SOLARPP:
                myMesh.material.color = Color.magenta;
                break;
            case ETileType.WATERPP:
                myMesh.material.color = Color.gray;
                break;
            case ETileType.ATOMPP:
                myMesh.material.color = Color.red;
                break;
            default:
                break;
        }
    }
}
