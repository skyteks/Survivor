using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static Health;

[DefaultExecutionOrder(-1000)]
public class GameManager : Singleton<GameManager>
{
    public static bool simulationPaused { get; private set; }

    public static void ToggleSimulationPause(bool toggle)
    {
        simulationPaused = toggle;
    }

    [Header("Register")]


    [SerializeField]
    private Register objectRegister = new Register();
    public Register register => objectRegister;


    public event HealthChangeEvent onPlayerHealthChange;

    void Awake()
    {
        register.onAdded += OnObjectAddedToRegister;
        register.onRemoved += OnObjectRemovedFromRegister;
    }

    private void OnObjectAddedToRegister(Object obj)
    {
        if (obj.GetType() == typeof(InputMovement))
        {
            Transform player = (obj as InputMovement).transform;
            Health health = player.GetComponentInChildren<Health>();
            health.onHealthChange += InformPlayerHealthChanged;
        }
    }

    private void OnObjectRemovedFromRegister(Object obj)
    {
        if (obj.GetType() == typeof(InputMovement))
        {
            Transform player = (obj as InputMovement).transform;
            Health health = player.GetComponentInChildren<Health>();
            health.onHealthChange -= InformPlayerHealthChanged;
        }
    }

    public void InformPlayerHealthChanged(float current, float max)
    {
        onPlayerHealthChange?.Invoke(current, max);
    }
}
