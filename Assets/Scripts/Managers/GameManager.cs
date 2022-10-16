using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static bool simulationPaused { get; private set; }

    public static void ToggleSimulationPause(bool toggle)
    {
        simulationPaused = toggle;
    }

    private Register objectRegister = new Register();
    public Register register => objectRegister;
}
