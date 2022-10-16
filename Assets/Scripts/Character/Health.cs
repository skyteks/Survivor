using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float incommingDmg, DamageTypes dmgType)
    {
        currentHealth = Mathf.Max(0f, currentHealth - incommingDmg);

        if (currentHealth == 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.ToggleSimulationPause(true);
    }
}
