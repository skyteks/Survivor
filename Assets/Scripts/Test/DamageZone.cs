using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DamageZone : MonoBehaviour
{
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private bool dot;
    [SerializeField]
    private DamageTypes type = DamageTypes.Physical;

    private Collider coll;

    private const float dotTiming = 0.5f;
    private Dictionary<Health, float> dotTargets = new();

    void Awake()
    {
        coll = GetComponent<Collider>();
    }

    void OnEnable()
    {
        dotTargets.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        if (dot)
        {
            return;
        }
        if (other.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage, type);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!dot)
        {
            return;
        }
        Health health = other.GetComponent<Health>();
        if (health == null)
        {
            return;
        }
        if (dotTargets.TryGetValue(health, out float lastTime))
        {
            if (Time.time < lastTime + dotTiming)
            {
                return;
            }
        }
        else
        {
            dotTargets.Add(health, Time.time);
        }
        health.TakeDamage(damage, type);
    }

    void OnTriggerExit(Collider other)
    {
        if (!dot)
        {
            return;
        }
        if (other.TryGetComponent<Health>(out Health health))
        {
            dotTargets.Remove(health);
        }
    }
}
