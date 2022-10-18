using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyOverhead : MonoBehaviour
{
    [SerializeField]
    private bool hideWhenFullLive = true;
    [SerializeField]
    private Image healthbarFill;
    [SerializeField]
    private TextMeshProUGUI healthbarText;

    private Health health;

    void Awake()
    {
        health = transform.root.GetComponentInChildren<Health>();
    }

    void OnEnable()
    {
        // Done in Health.OnEnable()
        //health.onHealthChange += OnHealthChange;
    }

    void OnDisable()
    {
        health.onHealthChange -= OnHealthChange;
    }

    public void OnHealthChange(float current, float max)
    {
        gameObject.SetActive(hideWhenFullLive ? (current < max) : true);

        healthbarFill.fillAmount = current / max;
        if (healthbarText != null)
        {
            healthbarText.text = $"{current} / {max}";
        }
    }

    [ExecuteInEditMode]
    void LateUpdate()
    {
        Vector3 lookAt = Camera.main.transform.position;
        Vector3 look = Camera.main.transform.forward;

        transform.LookAt(transform.position + look, Vector3.up);
    }
}
