using System;
using UnityEngine;
using UnityEngine.UI;

public class Restarter : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    public event Action OnRestart;
    public void ShowRestartButton()
    {
        _restartButton.gameObject.SetActive(true);
    }

    public void HideRestartButton()
    {
        _restartButton.gameObject.SetActive(false);
    }
    
    public void Restart() 
    {
        OnRestart?.Invoke();
    }
}