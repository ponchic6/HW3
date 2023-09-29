using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthAndExperienceMediator 
{
    private PlayerCharacteristics _playerCharacteristics;
    private HealthAndExperienceUI _healthAndExperienceUI;
    private Restarter _restarter;
    private ChangeButtons _changeButtons;

    public HealthAndExperienceMediator(PlayerCharacteristics playerCharacteristics, HealthAndExperienceUI healthAndExperienceUI,
        Restarter restarter, ChangeButtons changeButtons)
    {
        _healthAndExperienceUI = healthAndExperienceUI;
        _restarter = restarter;
        _changeButtons = changeButtons;
        _playerCharacteristics = playerCharacteristics;
        
        _playerCharacteristics.OnChangeHealth += ChangeHealthSlider;
        _playerCharacteristics.OnChangeXP += ChangeExperienceSlider;
        _playerCharacteristics.OnHealthZero += DefeatActivator;
        _playerCharacteristics.OnNewLevel += ChangeLevel;

        _restarter.OnRestart += ResetStats;
    }

    private void ChangeLevel()
    {
        _healthAndExperienceUI.UpdateLevel(_playerCharacteristics.Level);
    }


    private void ResetStats()
    {    
        _changeButtons.ShowButtons();
        _playerCharacteristics.ResetStats();
        _healthAndExperienceUI.ResetSliders();
        _healthAndExperienceUI.UpdateLevel(1);
        _restarter.HideRestartButton();
    }

    private void DefeatActivator()
    {
        _restarter.ShowRestartButton();
        _changeButtons.HideButtons();
    }

    private void ChangeExperienceSlider(int xp)
    {
        int ValueSlider = _playerCharacteristics.Xp - 100 * (_playerCharacteristics.Xp / 100);
        _healthAndExperienceUI.TakeExperienceUI(ValueSlider);
    }

    private void ChangeHealthSlider(int hp) 
        => _healthAndExperienceUI.TakeDamageUI(hp);
}
