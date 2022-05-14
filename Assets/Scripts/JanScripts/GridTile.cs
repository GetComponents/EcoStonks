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
                myMesh.material.color = Color.black;
                break;
            case ETileType.GASPP:
                MyEmmision = info.GasEmmision;
                MyEnergy = info.GasEnergyGain;
                MyMoneyGain = info.GasMoneyGain;
                myMesh.material.color = Color.yellow;
                break;
            case ETileType.WINDPP:
                MyEnergy = info.WindEnergyGain;
                MyMoneyGain = info.WindMoneyGain;
                myMesh.material.color = Color.cyan;
                break;
            case ETileType.SOLARPP:
                MyEnergy = info.SolarEnergyGain;
                MyMoneyGain = info.SolarMoneyGain;
                myMesh.material.color = Color.magenta;
                break;
            case ETileType.WATERPP:
                MyEnergy = info.WaterEnergyGain;
                MyMoneyGain = info.WaterMoneyGain;
                myMesh.material.color = Color.gray;
                break;
            case ETileType.ATOMPP:
                MyEnergy = info.AtomEnergyGain;
                MyMoneyGain = info.AtomMoneyGain;
                myMesh.material.color = Color.red;
                break;
            default:
                break;
        }
        JanGameManager.Instance.MoneyPerMonth += MyMoneyGain;
        JanGameManager.Instance.Energy += MyEnergy;
        JanGameManager.Instance.EmissionPerSecond += MyEmmision;
    }

    public void RemoveOldTile()
    {
        //JanGameManager.Instance.EmissionPerSecond -= MyEmmision;
        //JanGameManager.Instance.MoneyPerMonth -= MyMoneyGain;
        //JanGameManager.Instance.Energy -= MyEnergy;
        //MyMoneyGain = 0;
        //MyEmmision = 0;
        //MyEnergy = 0;
    }
}
