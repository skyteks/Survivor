using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager currentInstance;

    public Health health { get; private set; }

    void Awake()
    {
        currentInstance = this;
        health = GetComponentInChildren<Health>();
    }
}
