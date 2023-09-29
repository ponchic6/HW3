using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private PlayerCharacteristics _playerCharacteristics;
    [SerializeField] private HealthAndExperienceUI _hpXpUI;
    [SerializeField] private Restarter _restarter;
    [SerializeField] private ChangeButtons _changeButtons;
    public override void InstallBindings()
    {
        RegisterMediator();
        RegisterPlayerCharacteristic();
        RegisterHealthAndExperienceUI();
        RegisterRestarter();
        RegisterChangeButtons();
    }

    private void RegisterChangeButtons()
    {
        Container.Bind<ChangeButtons>().FromInstance(_changeButtons).AsSingle();
    }

    private void RegisterRestarter()
    {
        Container.Bind<Restarter>().FromInstance(_restarter).AsSingle();
    }

    private void RegisterHealthAndExperienceUI()
    {
        Container.Bind<HealthAndExperienceUI>().FromInstance(_hpXpUI).AsSingle();
    }

    private void RegisterPlayerCharacteristic()
    {
        Container.Bind<PlayerCharacteristics>().FromInstance(_playerCharacteristics).AsSingle();
    }

    private void RegisterMediator()
    {
        Container.Bind<HealthAndExperienceMediator>().AsSingle().NonLazy();
    }
}
