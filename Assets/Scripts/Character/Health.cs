using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum DamageTypes
{
    Physical,
    Fire,
    Frost,
    Unholy,
    Nature,
    Lightning,
}

public class Health : MonoBehaviour
{
    [SerializeField, ReadOnly]
    private float maxHealth = 100;
    [SerializeField, ReadOnly]
    private float currentHealth;

    public delegate void HealthChangeEvent(float current, float max);
    public event HealthChangeEvent onHealthChange;

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    [ContextMenu("TEST Take 10 DMG")]
    private void TestTake1Dmg()
    {
        TakeDamage(10, DamageTypes.Physical);
    }

    public void TakeDamage(float incommingDmg, DamageTypes dmgType)
    {
        currentHealth = Mathf.Max(0f, currentHealth - incommingDmg);

        onHealthChange?.Invoke(currentHealth, maxHealth);

        if (currentHealth == 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        
    }
}
