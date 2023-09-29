using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    private int _hp = MaxHP;
    private int _xp = 0;
    private int _level = 1;

    public int Level
    {
        get => _level;
        private set => _level = value;
    }

    public int Xp
    {
        get => _xp;
        private set => _xp = value;
    }


    public const int MaxHP = 100;
    public const int XPToNextLevel = 100;

    public event Action OnHealthZero;
    public event Action<int> OnChangeHealth;

    public event Action OnNewLevel;
    public event Action<int> OnChangeXP;

    public void ResetStats()
    {
        ResetHealt();
        ResetExperience();
        ResetLevel();
    }

    public void ResetHealt()
    {
        _hp = MaxHP;
    }

    public void ResetExperience()
    {
        _xp = 0;
    }

    public void ResetLevel()
    {
        _level = 1;
    }

    public void TakeDamage(int damage)
    {
        _hp -= damage;
        OnChangeHealth?.Invoke(damage);
        if (_hp <= 0)
        {
            OnHealthZero?.Invoke();
        }
    }

    public void TakeXP(int xp)
    {
        _xp += xp;
        OnChangeXP?.Invoke(xp);
        if (_xp >= XPToNextLevel)
        {
            _level += 1;
            OnNewLevel?.Invoke();
        }
    }
}
