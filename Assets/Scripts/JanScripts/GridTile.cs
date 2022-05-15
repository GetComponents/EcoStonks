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
            PlaceNewTile(value);
            m_myTile = value;
        }
    }
    [SerializeField]
    private ETileType m_myTile;
    public Vector3 MyPosition;
    GameObject currentPlacedObject;

    [SerializeField]
    private GameObject CoalPrefab, GasPrefab, SolarPrefab, WindPrefab, WaterPrefab, AtomPrefab, WoodPrefab;

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
                if (MyTile != ETileType.WOODS)
                {
                    JanGameManager.Instance.WoodCount++;
                    ConstructionAudio.Instance.PlayWoodConstruction();

                }
                currentPlacedObject = Instantiate(WoodPrefab, FindObjectOfType<JanGameManager>().PrefabParent.transform);
                currentPlacedObject.transform.position = transform.position;
                currentPlacedObject.transform.eulerAngles = new Vector3(0, Random.Range(0f, 360f), 0);
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
                ConstructionAudio.Instance.PlayPowerPlantConstruction();
                currentPlacedObject = Instantiate(CoalPrefab, FindObjectOfType<JanGameManager>().PrefabParent.transform);
                currentPlacedObject.transform.position = transform.position;
                break;
            case ETileType.GASPP:
                MyEmmision = info.GasEmmision;
                MyEnergy = info.GasEnergyGain;
                MyMoneyGain = info.GasMoneyGain;
                JanGameManager.Instance.GasCount++;
                ConstructionAudio.Instance.PlayPowerPlantConstruction();
                currentPlacedObject = Instantiate(GasPrefab, FindObjectOfType<JanGameManager>().PrefabParent.transform);
                currentPlacedObject.transform.position = transform.position;
                break;
            case ETileType.WINDPP:
                MyEnergy = info.WindEnergyGain;
                MyMoneyGain = info.WindMoneyGain;
                JanGameManager.Instance.WindCount++;
                ConstructionAudio.Instance.PlayPowerPlantConstruction();
                currentPlacedObject = Instantiate(WindPrefab, FindObjectOfType<JanGameManager>().PrefabParent.transform);
                currentPlacedObject.transform.position = transform.position;
                break;
            case ETileType.SOLARPP:
                MyEnergy = info.SolarEnergyGain;
                MyMoneyGain = info.SolarMoneyGain;
                JanGameManager.Instance.SolarCount++;
                ConstructionAudio.Instance.PlayPowerPlantConstruction();
                currentPlacedObject = Instantiate(SolarPrefab, FindObjectOfType<JanGameManager>().PrefabParent.transform);
                currentPlacedObject.transform.position = transform.position;
                break;
            case ETileType.WATERPP:
                MyEnergy = info.WaterEnergyGain;
                MyMoneyGain = info.WaterMoneyGain;
                JanGameManager.Instance.WaterCount++;
                ConstructionAudio.Instance.PlayPowerPlantConstruction();
                currentPlacedObject = Instantiate(WaterPrefab, FindObjectOfType<JanGameManager>().PrefabParent.transform);
                currentPlacedObject.transform.position = transform.position;
                break;
            case ETileType.ATOMPP:
                MyEnergy = info.AtomEnergyGain;
                MyMoneyGain = info.AtomMoneyGain;
                JanGameManager.Instance.AtomCount++;
                ConstructionAudio.Instance.PlayPowerPlantConstruction();
                currentPlacedObject = Instantiate(AtomPrefab, FindObjectOfType<JanGameManager>().PrefabParent.transform);
                currentPlacedObject.transform.position = transform.position;
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
        if (currentPlacedObject != null)
        {

            Destroy(currentPlacedObject);
            currentPlacedObject = null;
        }
    }
}
