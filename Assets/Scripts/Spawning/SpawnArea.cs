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
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 pos = Vector3.zero;
        do
        {
            pos.x = Random.Range(spawnarea.xMin, spawnarea.xMax);
            pos.z = Random.Range(spawnarea.yMin, spawnarea.yMax);
            pos += spawnarea.position.ToVector3XZ();
            pos -= spawnarea.size.ToVector3XZ() * 0.5f;

        } while (Vector3.Distance(PlayerManager.currentInstance.transform.position, pos) < 10);
        return pos;
    }

    public Vector3 GetRandomRaycastedPosition()
    {
        Vector3 pos = GetRandomPosition();
        Vector3 offset = Vector3.up * 5f;
        if (Physics.Raycast(pos + offset, Vector3.down, out RaycastHit hit, 10f, navMeshLayer))
        {
            return hit.point;
        }
        throw new System.Exception("No ground collider under spawnpoint");
    }

    public Vector3[] GetRandomRaycastedPositionsCircleArray(int count)
    {
        Vector3 pos = GetRandomPosition();
        Vector3 offset = Vector3.up * 5f;
        Vector3[] array = new Vector3[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 vector = Vector3.zero;
            bool success = false;
            do
            {
                Vector3 rand = Random.insideUnitCircle.ToVector3XZ() * count;
                success = Physics.Raycast(pos + offset + rand, Vector3.down, out RaycastHit hit, 10f, navMeshLayer);
                vector = hit.point;
            } while (!success);
            array[i] = vector;
        }
        return array;
    }
}