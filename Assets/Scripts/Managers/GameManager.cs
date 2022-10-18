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

    [Header("Wave 01")]
    [SerializeField]
    private GameObject enemyPrefab01;
    [SerializeField]
    private float enemyDelay01 = 1f;
    [SerializeField]
    private int enemyAmount01 = 10;

    void Start()
    {
        StartCoroutine(Wave01());
    }

    private IEnumerator Wave01()
    {
        SpawnArea spawnArea = SpawnArea.Instance;

        for (int i = 0; i <= enemyAmount01; i++)
        {
            Vector3 pos = spawnArea.GetRandomRaycastedPosition();

            GameObject instance = Instantiate(enemyPrefab01, pos, Quaternion.identity);
            instance.name = string.Concat(instance.name, "[", i, "]");

            if (enemyDelay01 > float.Epsilon)
            {
            yield return Yielders.Get(enemyDelay01);
            }
        }
    }
}
