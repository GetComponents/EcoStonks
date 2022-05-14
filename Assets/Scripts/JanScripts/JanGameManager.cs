using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[DisallowMultipleComponent]
public class JanGameManager : MonoBehaviour
{
    public float Currency
    {
        get => m_currency;
        set
        {
            m_currency = value;
            OnCurrencyChanged?.Invoke();
        }
    }
    public int Energy
    {
        get => m_energy;
        set
        {
            m_energy = value;
            OnEnergyChanged?.Invoke();
        }
    }
    public float TotalEmission
    {
        get => m_emission;
        set
        {
            m_emission = value;
            OnEmissionChanged?.Invoke();
        }
    }

    public int EnergyGoal;

    public float EmmissionPerSecond;


    public const float SECONDSPERMONTH = 1;
    public float EmissionPerSecond;
    public float BuildingMoneyPerMonth;
    public float PassiveMoneyPerMonth;

    public int monthCounter;
    public int cycleCounter;

    [SerializeField] private float m_currency;
    [SerializeField] private int m_energy;
    [SerializeField] private float m_emission;

    public static JanGameManager Instance;

    public UnityEvent OnCurrencyChanged;
    public UnityEvent OnEnergyChanged;
    public UnityEvent OnEmissionChanged;
    public UnityEvent OnMonthChanged;
    public UnityEvent OnBuildingChanged;
    public EventCardHolder eventCards;

    public List<EventCards> WoodEvents, CoalEvents, GasEvents, SolarEvents, WindEvents, WaterEvents, AtomEvents;
    public int WoodCount
    {
        get => m_woodCount;
        set
        {
            if (value == 0)
            {
                foreach (EventCards card in WoodEvents)
                {
                    eventCards.EventCardPool.Remove(card);
                }
            }
            else if (m_woodCount == 0 && value == 1)
            {
                foreach (EventCards card in WoodEvents)
                {
                    eventCards.EventCardPool.Add(card);
                }
            }
            m_woodCount = value;
        }
    }
    public int CoalCount
    {
        get => m_coalCount;
        set
        {
            if (value == 0)
            {
                foreach (EventCards card in CoalEvents)
                {
                    eventCards.EventCardPool.Remove(card);
                }
            }
            else if (m_coalCount == 0 && value == 1)
            {
                foreach (EventCards card in CoalEvents)
                {
                    eventCards.EventCardPool.Add(card);
                }
            }
            m_coalCount = value;
        }
    }
    public int GasCount
    {
        get => m_gasCount;
        set
        {
            if (value == 0)
            {
                foreach (EventCards card in GasEvents)
                {
                    eventCards.EventCardPool.Remove(card);
                }
            }
            else if (m_gasCount == 0 && value == 1)
            {
                foreach (EventCards card in GasEvents)
                {
                    eventCards.EventCardPool.Add(card);
                }
            }
            m_gasCount = value;
        }
    }
    public int SolarCount
    {
        get => m_solarCount;
        set
        {
            if (value == 0)
            {
                foreach (EventCards card in SolarEvents)
                {
                    eventCards.EventCardPool.Remove(card);
                }
            }
            else if (value == 1 && m_solarCount == 0)
            {
                foreach (EventCards card in SolarEvents)
                {
                    eventCards.EventCardPool.Add(card);
                }
            }
            m_solarCount = value;
        }
    }
    public int WindCount
    {
        get => m_windCount;
        set
        {
            if (value == 0)
            {
                foreach (EventCards card in WindEvents)
                {
                    eventCards.EventCardPool.Remove(card);
                }
            }
            else if (m_windCount == 0 && value == 1)
            {
                foreach (EventCards card in WindEvents)
                {
                    eventCards.EventCardPool.Add(card);
                }
            }
            m_windCount = value;
        }
    }
    public int WaterCount
    {
        get => m_waterCount;
        set
        {
            if (value == 0)
            {
                foreach (EventCards card in WaterEvents)
                {
                    eventCards.EventCardPool.Remove(card);
                }
            }
            else if (m_waterCount == 0 && value == 1)
            {
                foreach (EventCards card in WaterEvents)
                {
                    eventCards.EventCardPool.Add(card);
                }
            }
            m_waterCount = value;
        }
    }
    public int AtomCount
    {
        get => m_atomCount;
        set
        {
            if (value == 0)
            {
                foreach (EventCards card in AtomEvents)
                {
                    eventCards.EventCardPool.Remove(card);
                }
            }
            else if (m_atomCount == 0 && value == 1)
            {
                foreach (EventCards card in AtomEvents)
                {
                    eventCards.EventCardPool.Add(card);
                }
            }
            m_atomCount = value;
        }
    }

    private int m_woodCount, m_coalCount, m_gasCount, m_solarCount, m_windCount, m_waterCount, m_atomCount;

    public List<ETileType> CurrentBuildings
    {
        get => m_currentBuildings;
        set
        {
            m_currentBuildings = value;
            OnBuildingChanged?.Invoke();
        }
    }

    private List<ETileType> m_currentBuildings;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        OnCurrencyChanged = new UnityEvent();
        EnergyGoal = 5;
        Currency = 500;
    }

    private void Start()
    {
        eventCards = GetComponent<EventCardHolder>();
        StartCoroutine(MonthCycle());
    }

    IEnumerator MonthCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(SECONDSPERMONTH);
            OnMonthChanged?.Invoke();
            Currency += BuildingMoneyPerMonth;
            Currency += PassiveMoneyPerMonth;
            monthCounter++;
            if (monthCounter == 3 || monthCounter == 6)
            {
                ReadCard();
            }
            if (monthCounter == 6)
            {
                cycleCounter++;
                CheckEnergyGoal();
                monthCounter = 0;
            }
        }
    }

    private void CheckEnergyGoal()
    {
        if (Energy >= EnergyGoal)
        {
            EnergyGoal += cycleCounter * 10;
            OnEnergyChanged?.Invoke();
            return;
        }
        else
        {
            Debug.Log("You Lost");
        }
    }

    public void SpawnTileRandomly(ETileType _tile)
    {
        if (_tile == ETileType.WATERPP)
        {
            foreach (GridTile tile in FindObjectsOfType<GridTile>())
            {
                if (tile.MyTile == ETileType.WATER)
                {
                    tile.MyTile = _tile;
                    break;
                }
            }
        }
        else
        {
            bool foundTile = false;
            foreach (GridTile tile in FindObjectsOfType<GridTile>())
            {
                if (tile.MyTile == ETileType.EMPTY)
                {
                    tile.MyTile = _tile;
                    foundTile = true;
                    break;
                }
            }
            if (foundTile == false)
            {
                foreach (GridTile tile in FindObjectsOfType<GridTile>())
                {
                    if (tile.MyTile == ETileType.WOODS)
                    {
                        tile.MyTile = _tile;
                        foundTile = true;
                        break;
                    }
                }
            }
        }
    }

    private void ReadCard()
    {
        if (eventCards.EventCardPool.Count > 0)
        {
            eventCards.EventCardPool?[Random.Range(0, eventCards.EventCardPool.Count)].ShowCard();
        }
    }

    private void Update()
    {
        TotalEmission += EmissionPerSecond * Time.deltaTime;
    }
}
