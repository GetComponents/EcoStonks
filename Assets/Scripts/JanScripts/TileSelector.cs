using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileSelector : MonoBehaviour
{
    Camera myCamera;
    [SerializeField]
    GameObject SelectedHighlighter;
    GridTile selectedTile;
    public bool SelectingTile;
    public ETileType HeldItem;
    float DropPrice;

    public UnityEvent OnBuildingPlaced;

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
                //else if (objectHit.transform.gameObject.layer == 5) //UI Layer
                //{
                //    return;
                //}
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (HeldItem == ETileType.WATERPP)
                {
                    if (selectedTile.MyTile == ETileType.WATER)
                    {
                        SelectingTile = false;
                        SelectedHighlighter.transform.position = new Vector3(200, SelectedHighlighter.transform.position.y, 200);
                        selectedTile.MyTile = HeldItem;
                        JanGameManager.Instance.Currency -= DropPrice;
                    }
                }
                else if (selectedTile.MyTile != ETileType.CITY && selectedTile.MyTile != ETileType.WATER)
                {
                    SelectingTile = false;
                    SelectedHighlighter.transform.position = new Vector3(200, SelectedHighlighter.transform.position.y, 200);
                    selectedTile.MyTile = HeldItem;
                    JanGameManager.Instance.Currency -= DropPrice;
                    PlayerStats.Instance.MoneySpent += DropPrice;
                }
            }
        }
    }

    public void ChangeHeldItem(int _itemType)
    {
        if (Time.timeScale == 1)
        {

            HeldItem = (ETileType)_itemType;
            switch (HeldItem)
            {
                case ETileType.WOODS:
                    if (JanGameManager.Instance.Currency >= BuildingInfo.Instance.WoodPrice)
                    {
                        foreach (GridTile tile in FindObjectsOfType<GridTile>())
                        {
                            if (tile.MyTile == ETileType.EMPTY)
                            {
                                tile.MyTile = ETileType.WOODS;
                                JanGameManager.Instance.Currency -= BuildingInfo.Instance.WoodPrice;
                                PlayerStats.Instance.MoneySpent += BuildingInfo.Instance.WoodPrice;
                                break;
                            }
                        }
                        //DropPrice = BuildingInfo.Instance.WoodPrice;
                        //SelectingTile = true;
                    }
                    break;
                case ETileType.COALPP:
                    if (JanGameManager.Instance.Currency >= BuildingInfo.Instance.CoalPrice)
                    {
                        DropPrice = BuildingInfo.Instance.CoalPrice;
                        SelectingTile = true;
                    }
                    break;
                case ETileType.GASPP:
                    if (JanGameManager.Instance.Currency >= BuildingInfo.Instance.GasPrice)
                    {
                        DropPrice = BuildingInfo.Instance.GasPrice;
                        SelectingTile = true;
                    }
                    break;
                case ETileType.WINDPP:
                    if (JanGameManager.Instance.Currency >= BuildingInfo.Instance.WindPrice)
                    {
                        DropPrice = BuildingInfo.Instance.WindPrice;
                        SelectingTile = true;
                    }
                    break;
                case ETileType.SOLARPP:
                    if (JanGameManager.Instance.Currency >= BuildingInfo.Instance.SolarPrice)
                    {
                        DropPrice = BuildingInfo.Instance.SolarPrice;
                        SelectingTile = true;
                    }
                    break;
                case ETileType.WATERPP:
                    if (JanGameManager.Instance.Currency >= BuildingInfo.Instance.WaterPrice)
                    {
                        DropPrice = BuildingInfo.Instance.WaterPrice;
                        SelectingTile = true;
                    }
                    break;
                case ETileType.ATOMPP:
                    if (JanGameManager.Instance.Currency >= BuildingInfo.Instance.AtomPrice)
                    {
                        DropPrice = BuildingInfo.Instance.WaterPrice;
                        SelectingTile = true;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
