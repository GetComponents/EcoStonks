using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingInfo : MonoBehaviour
{
    public static BuildingInfo Instance;

    [SerializeField]
    TextMeshProUGUI woodMoneyText;
    public float WoodPrice
    {
        get => m_woodPrice;
        set
        {
            woodMoneyText.text = $"{value.ToString("F0")}$";
            m_woodPrice = value;
        }
    }
    [SerializeField]
    private float m_woodPrice;
    public float WoodEmmesion;

    [Space]
    [SerializeField]
    TextMeshProUGUI coalMoneyText;
    public float CoalPrice
    {
        get => m_coalPrice;
        set
        {
            coalMoneyText.text = $"{value.ToString("F0")}$";
            m_coalPrice = value;
        }
    }
    [SerializeField]
    private float m_coalPrice;
    public float CoalMoneyGain;
    public int CoalEnergyGain;
    public float CoalEmminsion;

    [Space]
    [SerializeField]
    TextMeshProUGUI gasMoneyText;
    public float GasPrice
    {
        get => m_gasPrice;
        set
        {
            gasMoneyText.text = $"{value.ToString("F0")}$";
            m_gasPrice = value;
        }
    }
    [SerializeField]
    private float m_gasPrice;
    public float GasMoneyGain;
    public int GasEnergyGain;
    public float GasEmmision;

    [Space]
    [SerializeField]
    TextMeshProUGUI windMoneyText;
    public float WindPrice
    {
        get => m_windPrice;
        set
        {
            windMoneyText.text = $"{value.ToString("F0")}$";
            m_windPrice = value;
        }
    }
    [SerializeField]
    private float m_windPrice;
    public float WindMoneyGain;
    public int WindEnergyGain;

    [Space]
    [SerializeField]
    TextMeshProUGUI solarMoneyText;
    public float SolarPrice
    {
        get => m_solarPrice;
        set
        {
            solarMoneyText.text = $"{value.ToString("F0")}$";
            m_solarPrice = value;
        }
    }
    [SerializeField]
    private float m_solarPrice;
    public float SolarMoneyGain;
    public int SolarEnergyGain;

    [Space]
    [SerializeField]
    TextMeshProUGUI waterMoneyText;
    public float WaterPrice
    {
        get => m_waterPrice;
        set
        {
            waterMoneyText.text = $"{value.ToString("F0")}$";
            m_waterPrice = value;
        }
    }
    [SerializeField]
    private float m_waterPrice;
    public float WaterMoneyGain;
    public int WaterEnergyGain;

    [Space]
    [SerializeField]
    TextMeshProUGUI atomMoneyText;
    public float AtomPrice
    {
        get => m_atomPrice;
        set
        {
            atomMoneyText.text = $"{value.ToString("F0")}$";
            m_atomPrice = value;
        }
    }
    [SerializeField]
    private float m_atomPrice;
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
