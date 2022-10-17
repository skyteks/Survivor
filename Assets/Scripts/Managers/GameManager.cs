using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static Health;

public class GameManager : Singleton<GameManager>
{
    public static bool simulationPaused { get; private set; }

    public static void ToggleSimulationPause(bool toggle)
    {
        simulationPaused = toggle;
    }
}
