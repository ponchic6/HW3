using UnityEngine;
using UnityEngine.UI;

public class ChangeButtons : MonoBehaviour
{
    [SerializeField] private Button _healthChangeButton;
    [SerializeField] private Button _experienceChangeButton;

    public void HideButtons()
    {
        _healthChangeButton.gameObject.SetActive(false);
        _experienceChangeButton.gameObject.SetActive(false);
    }

    public void ShowButtons()
    {
        _healthChangeButton.gameObject.SetActive(true);
        _experienceChangeButton.gameObject.SetActive(true);
    }
}