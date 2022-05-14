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


    public const float SECONDSPERMONTH = 5;
    public float EmissionPerSecond;
    public float MoneyPerMonth;

    private int monthCounter;
    private int cycleCounter;

    [SerializeField] private float m_currency;
    [SerializeField] private int m_energy;
    [SerializeField] private float m_emission;

    public static JanGameManager Instance;

    public UnityEvent OnCurrencyChanged;
    public UnityEvent OnEnergyChanged;
    public UnityEvent OnEmissionChanged;

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
        StartCoroutine(MonthCycle());
    }

    IEnumerator MonthCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(SECONDSPERMONTH);
            Currency += MoneyPerMonth;
            monthCounter++;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Currency += 100;
        }
        TotalEmission += EmissionPerSecond * Time.deltaTime;
    }
}
