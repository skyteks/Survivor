using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera cam;

    void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        if (cam != Camera.main)
        {
            Debug.LogError("Camera is not set to 'MainCamera'");
        }
    }

    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerManager.currentInstance.transform.position, Time.deltaTime * 100f);
    }
}
