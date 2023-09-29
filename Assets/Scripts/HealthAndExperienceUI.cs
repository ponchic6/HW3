using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndExperienceUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _xpSlider;
    [SerializeField] private TextMeshProUGUI _levelText;

    public void ResetSliders()
    {
        ResetHealthSlider();
        TakeExperienceUI(0);
    }

    public void ResetHealthSlider()
    {
        _healthSlider.value = 100;
    }

    public void TakeDamageUI(int damage)
    {
        _healthSlider.value -= damage;
    }

    public void TakeExperienceUI(int xp)
    {
        _xpSlider.value = xp;
    }

    public void UpdateLevel(int _level)
    {
        _levelText.text = $"Level: {_level}";
    }
}