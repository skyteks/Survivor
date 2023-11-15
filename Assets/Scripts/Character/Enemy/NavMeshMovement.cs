using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Rigidbody rigid;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rigid.isKinematic = true;
    }

    void OnEnable()
    {
        StartCoroutine(GoToPlayer());
    }

    private IEnumerator GoToPlayer()
    {
        yield return Yielders.Get(1f);

        for (; ; )
        {
            agent.destination = PlayerManager.currentInstance.transform.position;
            yield return null;
        }
    }
}
