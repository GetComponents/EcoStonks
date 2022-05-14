using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JanUIManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI moneyDisplayText, emissionDisplay, energyDisplay;
    void Start()
    {
        JanGameManager.Instance.OnCurrencyChanged.AddListener(ChangeMoneyDisplay);
        JanGameManager.Instance.OnEmissionChanged.AddListener(ChangeEmissionDisplay);
        JanGameManager.Instance.OnEnergyChanged.AddListener(ChangeEnergyDisplay);
        ChangeEnergyDisplay();
        ChangeMoneyDisplay();
    }

    private void ChangeMoneyDisplay()
    {
        moneyDisplayText.text = $"{JanGameManager.Instance.Currency}$";
    }

    private void ChangeEmissionDisplay()
    {
        emissionDisplay.text = $"Emission: {JanGameManager.Instance.TotalEmission.ToString("F1")}";
    }

    private void ChangeEnergyDisplay()
    {
        energyDisplay.text = $"Energy: {JanGameManager.Instance.Energy} / {JanGameManager.Instance.EnergyGoal}";
    }
}
