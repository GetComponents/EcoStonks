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
            RemoveOldTile();
            m_myTile = value;
            PlaceNewTile(value);
        }
    }
    [SerializeField]
    private ETileType m_myTile;
    public Vector3 MyPosition;

    private void Start()
    {
        name = $"{MyPosition.x} / {MyPosition.z}";
    }

    public float MyMoneyGain, MyEmmision;
    public int MyEnergy;

    [ContextMenu("ClickMe")]
    public void OnClickMe()
    {
        Debug.Log("I got Clicked");
    }

    [ExecuteInEditMode]
    public void PlaceNewTile(ETileType newTile)
    {
        BuildingInfo info = FindObjectOfType<BuildingInfo>();
        switch (newTile)
        {
            case ETileType.NONE:
                break;
            case ETileType.WOODS:
                MyEmmision = info.WoodEmmesion;
                JanGameManager.Instance.WoodCount++;
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
                MyEmmision = info.CoalEmminsion;
                MyEnergy = info.CoalEnergyGain;
                MyMoneyGain = info.CoalMoneyGain;
                JanGameManager.Instance.CoalCount++;
                myMesh.material.color = Color.black;
                break;
            case ETileType.GASPP:
                MyEmmision = info.GasEmmision;
                MyEnergy = info.GasEnergyGain;
                MyMoneyGain = info.GasMoneyGain;
                JanGameManager.Instance.GasCount++;
                myMesh.material.color = Color.yellow;
                break;
            case ETileType.WINDPP:
                MyEnergy = info.WindEnergyGain;
                MyMoneyGain = info.WindMoneyGain;
                JanGameManager.Instance.WindCount++;
                myMesh.material.color = Color.cyan;
                break;
            case ETileType.SOLARPP:
                MyEnergy = info.SolarEnergyGain;
                MyMoneyGain = info.SolarMoneyGain;
                JanGameManager.Instance.SolarCount++;
                myMesh.material.color = Color.magenta;
                break;
            case ETileType.WATERPP:
                MyEnergy = info.WaterEnergyGain;
                MyMoneyGain = info.WaterMoneyGain;
                JanGameManager.Instance.WaterCount++;
                myMesh.material.color = Color.gray;
                break;
            case ETileType.ATOMPP:
                MyEnergy = info.AtomEnergyGain;
                MyMoneyGain = info.AtomMoneyGain;
                JanGameManager.Instance.AtomCount++;
                myMesh.material.color = Color.red;
                break;
            default:
                break;
        }
        JanGameManager.Instance.BuildingMoneyPerMonth += MyMoneyGain;
        JanGameManager.Instance.Energy += MyEnergy;
        JanGameManager.Instance.EmissionPerSecond += MyEmmision;
    }

    public void RemoveOldTile()
    {
        switch (MyTile)
        {
            case ETileType.WOODS:
                JanGameManager.Instance.WoodCount--;
                break;
            case ETileType.COALPP:
                JanGameManager.Instance.CoalCount--;
                break;
            case ETileType.GASPP:
                JanGameManager.Instance.GasCount--;
                break;
            case ETileType.WINDPP:
                JanGameManager.Instance.WindCount--;
                break;
            case ETileType.SOLARPP:
                JanGameManager.Instance.SolarCount--;
                break;
            case ETileType.WATERPP:
                JanGameManager.Instance.WaterCount--;
                break;
            case ETileType.ATOMPP:
                JanGameManager.Instance.AtomCount--;
                break;
            default:
                break;
        }
    }
}
