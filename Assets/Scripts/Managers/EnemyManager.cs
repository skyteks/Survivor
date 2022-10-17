using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        health = GetComponentInChildren<Health>();
    }

    void OnEnable()
    {
        health.onHealthChange += OnHealthChange;
    }

    void OnDisable()
    {
        health.onHealthChange -= OnHealthChange;
    }

    private void OnHealthChange(float current, float max)
    {
        if (current <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
