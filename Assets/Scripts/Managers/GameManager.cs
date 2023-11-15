using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static Health;
using static WaveInfo;

public class GameManager : Singleton<GameManager>
{
    public static bool simulationPaused;

    [SerializeField]
    private WaveInfo[] waves;

    private Coroutine activeWave;
    private Queue<WaveInfo> queue;

    void Start()
    {
        queue = new Queue<WaveInfo>(waves);
    }

    void Update()
    {
        if (simulationPaused || activeWave != null)
        {
            return;
        }

        if (queue.Count > 0)
        {
            WaveInfo current = queue.Dequeue();
            activeWave = StartCoroutine(RunWave(current));
        }
    }

    public IEnumerator RunWave(WaveInfo wave)
    {
        SpawnArea spawnArea = SpawnArea.Instance;

        for (int i = 0; i < wave.subWaves.Length; i++)
        {
            SubWaveInfo current = wave.subWaves[i];
            GameObject prefab = wave.enemyPrefabs[current.enemyIndex];

            Vector3[] pos = null; 
            if (current.enemyCount == 1)
            {
                pos = new Vector3[1];
                pos[0] = spawnArea.GetRandomRaycastedPosition();
            }
            else
            {
                pos = spawnArea.GetRandomRaycastedPositionsCircleArray(current.enemyCount);
            }

            for (int j = 0; j < current.enemyCount; j++)
            {
                GameObject instance = Instantiate(prefab, pos[j], Quaternion.identity);
                instance.name = string.Concat(instance.name, "[", j + 1, "]");
                instance.SetActive(true);
            }

            yield return Yielders.Get(wave.delayBetweenSubwaves);
        }
        activeWave = null;
    }
}
