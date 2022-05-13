using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    Camera myCamera;
    [SerializeField]
    GameObject SelectedHighlighter;
    GridTile selectedTile;
    public bool SelectingTile;
    public ETileType HeldItem;

    void Start()
    {
        myCamera = Camera.main;
    }

    void Update()
    {
        if (SelectingTile)
        {
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.tag == "Tile")
                {
                    selectedTile = objectHit.GetComponent<GridTile>();
                    SelectedHighlighter.transform.position = new Vector3(objectHit.position.x, SelectedHighlighter.transform.position.y, objectHit.position.z);
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SelectingTile = false;
                SelectedHighlighter.transform.position = new Vector3(200, SelectedHighlighter.transform.position.y, 200);
                selectedTile.MyTile = HeldItem;
            }
        }
    }

    public void ChangeHeldItem(int _itemType)
    {
        HeldItem = (ETileType)_itemType;
        switch (HeldItem)
        {
            case ETileType.WOODS:
                break;
            case ETileType.COALPP:
                break;
            case ETileType.GASPP:
                break;
            case ETileType.WINDPP:
                break;
            case ETileType.SOLARPP:
                break;
            case ETileType.WATERPP:
                break;
            case ETileType.ATOMPP:
                break;
            default:
                break;
        }
        SelectingTile = true;
    }
}
