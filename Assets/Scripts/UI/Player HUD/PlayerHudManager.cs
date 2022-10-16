using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudManager : MonoBehaviour
{
    [SerializeField]
    private Image healthbarFill;
    [SerializeField]
    private TextMeshProUGUI healthbarText;

    void OnEnable()
    {
        GameManager.instance.onPlayerHealthChange += OnHealthChange;
    }

    void OnDisable()
    {
        GameManager.instance.onPlayerHealthChange -= OnHealthChange;
    }

    public void OnHealthChange(float current, float max)
    {
        healthbarFill.fillAmount = current / max;
        healthbarText.text = $"{current} / {max}";
    }
}
