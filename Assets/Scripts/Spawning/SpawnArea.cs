using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnArea : Singleton<SpawnArea>
{
    [SerializeField]
    private Rect spawnarea;
    [SerializeField]
    private LayerMask navMeshLayer;

    void Awake()
    {
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnarea.position.ToVector3XZ(), spawnarea.size.ToVector3XZ());
        Gizmos.color = Color.red.ToWithA(0.2f);
        //Gizmos.DrawCube(spawnarea.position.ToVector3XZ(), spawnarea.size.ToVector3XZ());
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 pos = Vector3.zero;
        pos.x = Random.Range(spawnarea.xMin, spawnarea.xMax);
        pos.z = Random.Range(spawnarea.yMin, spawnarea.yMax);
        pos += spawnarea.position.ToVector3XZ();
        pos -= spawnarea.size.ToVector3XZ() * 0.5f;
        return pos;
    }

    public Vector3 GetRandomRaycastedPosition()
    {
        Vector3 pos = GetRandomPosition();
        if (Physics.Raycast(pos + Vector3.up * 5f, Vector3.down, out RaycastHit hit, 10f, navMeshLayer))
        {
            return hit.point;
        }
        throw new System.Exception("No ground collider under spawnpoint");
    }
}
