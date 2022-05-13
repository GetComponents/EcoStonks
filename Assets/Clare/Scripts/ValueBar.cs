using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueBar : MonoBehaviour
{
    [SerializeField] Slider m_slider;
    [SerializeField] private float m_maxStartValue = 100f;

    private void Awake()
    {
        m_slider.value = SetSliderValue(m_maxStartValue);
    }

    public float SetSliderValue(float _value)
    {
        return m_slider.value = _value;
    }
}