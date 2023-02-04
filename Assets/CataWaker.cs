using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CataWaker : MonoBehaviour
{
    [SerializeField]
    Transform target;

    NavMeshAgent agent;

    private void Start()
    {
        if(!agent)
        agent = GetComponent<NavMeshAgent>();
    }

    public void WakeCaterpiller()
    {
        //target = tgt;
        //Target is always leaf, it's cool
        agent.SetDestination(target.position);
    }
}
