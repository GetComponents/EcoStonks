using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public static BuildingInfo Instance;

    public float WoodPrice;
    public float WoodEmmesion;
    [Space]
    public float CoalPrice;
    public float CoalMoneyGain;
    public int CoalEnergyGain;
    public float CoalEmminsion;
    [Space]
    public float GasPrice;
    public float GasMoneyGain;
    public int GasEnergyGain;
    public float GasEmmision;
    [Space]
    public float WindPrice;
    public float WindMoneyGain;
    public int WindEnergyGain;
    [Space]
    public float SolarPrice;
    public float SolarMoneyGain;
    public int SolarEnergyGain;
    [Space]
    public float WaterPrice;
    public float WaterMoneyGain;
    public int WaterEnergyGain;
    [Space]
    public float AtomPrice;
    public float AtomMoneyGain;
    public int AtomEnergyGain;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
