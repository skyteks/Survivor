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
        yield return new WaitForSeconds(1f);

        Transform player = (GameManager.Instance.register.GetFirstObjectOfType(typeof(InputMovement)) as InputMovement).transform;

        for (; ; )
        {
            agent.destination = player.position;
            yield return null;
        }
    }
}
