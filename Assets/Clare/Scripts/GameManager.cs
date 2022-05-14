using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[DisallowMultipleComponent]
public class GameManager : MonoBehaviour
{
    [SerializeField] private LightingCircle m_lightingCircle;

    [SerializeField] TextMeshProUGUI m_timeOfDayText;
    private float m_gameStarttime = 0f;

    private UnityEvent onCurrencyChanged;
    private UnityEvent onEnergyChanged;
    private UnityEvent onEmissionChanged;

    public uint Currency
    {
        get => m_currency;
        set
        {
            onCurrencyChanged?.Invoke();
            m_currency = value;
        }
    }

    [SerializeField] private uint m_currency;
    [SerializeField] private uint m_energy;
    [SerializeField] private uint m_emission;

    public static GameManager Instance;

    public UnityEvent OnCurrencyChanged { get => onCurrencyChanged; set => onCurrencyChanged = value; }
    public UnityEvent OnEnergyChanged { get => onEnergyChanged; set => onEnergyChanged = value; }
    public UnityEvent OnEmissionChanged { get => onEmissionChanged; set => onEmissionChanged = value; }

    private void Awake()
    {
        m_gameStarttime = Time.time;

        if (Instance is null)
            Instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Update()
    {
        //Debug.Log($"Time of Day: {m_lightingCircle.GetComponent<LightingCircle>().TimeOfDay}.");
        if(m_lightingCircle.GetComponent<LightingCircle>().TimeOfDay == 0f)
            m_gameStarttime = Time.time;

        //m_songtimeLeftCountUp = Time.time - m_gameStarttime;
        DisplayTimeOfDay(m_lightingCircle.GetComponent<LightingCircle>().TimeOfDay);
    }

    private void DisplayTimeOfDay(float _timeOfDay)
    {
        //Stunden des Tages. (int)-cast ersetzte 'Mathf.FloorToInt(_timeOfDay);'
        float hours = (int)_timeOfDay;
        //Berechnung der Minuten.
        float minutes = (_timeOfDay - (int)_timeOfDay) * 60f;

        m_timeOfDayText.text = string.Format("Daytime {0:00}:{1:00}", hours, minutes);        
    }
}