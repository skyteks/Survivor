using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave ", menuName = "ScriptableObjects/Wave")]
public class WaveInfo : ScriptableObject
{
    [System.Serializable]
    public struct SubWaveInfo
    {
        [Min(0)]
        public int enemyIndex;
        [Min(0)]
        public int enemyCount;
    }

    public GameObject[] enemyPrefabs;
    public SubWaveInfo[] subWaves;
    [Min(0f)]
    public float delayBetweenSubwaves;
}
