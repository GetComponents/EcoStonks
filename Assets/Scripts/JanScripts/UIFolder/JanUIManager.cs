using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JanUIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI moneyDisplayText, monthDisplay;
    [SerializeField]
    Image EmissionUI, EnergyUI, EnergyForeground, TimeUI;
    
    void Start()
    {
        JanGameManager.Instance.OnCurrencyChanged.AddListener(ChangeMoneyDisplay);
        JanGameManager.Instance.OnEmissionChanged.AddListener(ChangeEmissionDisplay);
        JanGameManager.Instance.OnEnergyChanged.AddListener(ChangeEnergyDisplay);
        JanGameManager.Instance.OnMonthChanged.AddListener(ChangeMonthDisplay);
        ChangeEnergyDisplay();
        ChangeMoneyDisplay();
        ChangeMonthDisplay();
    }

    private void ChangeMoneyDisplay()
    {
        moneyDisplayText.text = $"{JanGameManager.Instance.Currency.ToString("F0")}";
    }

    private void ChangeEmissionDisplay()
    {
        EmissionUI.fillAmount = JanGameManager.Instance.TotalEmission / 100;
    }

    private void ChangeEnergyDisplay()
    {
        EnergyUI.fillAmount = (float)JanGameManager.Instance.Energy / (float)JanGameManager.Instance.EnergyGoal;
        if ((float)JanGameManager.Instance.Energy / (float)JanGameManager.Instance.EnergyGoal >= 1)
        {
            EnergyForeground.color = Color.yellow;
        }
        else
        {
            EnergyForeground.color = Color.white;
        }
    }

    private void ChangeMonthDisplay()
    {
        TimeUI.fillAmount = ((float)JanGameManager.Instance.monthCounter +1) / 6f;
    }
}
