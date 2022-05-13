using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class UIManager : MonoBehaviour
{
    [SerializeField] private ValueBar m_valueBar;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance is null)
            Instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void Start()
    {
        GameManager.Instance.OnCurrencyChanged.AddListener(ChangeValueBar);
    }

    private void ChangeValueBar()
    {
        UpdateValueBar(GameManager.Instance.Currency);
    }

    private void UpdateValueBar(float _value)
    {
        m_valueBar.GetComponent<ValueBar>().SetSliderValue(_value);
    }
}