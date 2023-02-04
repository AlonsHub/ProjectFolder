using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EaterChicken : MonoBehaviour
{

    [SerializeField]
    Transform target;

    [SerializeField]
    LayerMask groundLayermask;
    NavMeshAgent agent;



    private void Start()
    {
        if (!agent)
            agent = GetComponent<NavMeshAgent>();

    }

    public void WakeChicken()
    {
        //target = tgt;
        //Target is always leaf, it's cool

        agent.SetDestination(target.position);
        StartCoroutine(nameof(FixTarget));
    }

    IEnumerator FixTarget()
    {
        while (true)
        {

            agent.SetDestination(target.position);


            yield return new WaitForSeconds(.3f);
            if(agent.remainingDistance < agent.stoppingDistance)
            {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
            }
            else
            {
                agent.isStopped = false;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        GroundAngle();

    }

    void GroundAngle()
    {

        Vector3 point1, point2;

        RaycastHit hit;

        Physics.Raycast(transform.position + transform.forward * 1f + Vector3.up, -transform.up, out hit, 25.01f, groundLayermask);
        Debug.Log(hit.transform);
        point1 = hit.point;

        Debug.Log(point1);
        Physics.Raycast(transform.position - transform.forward * 1f + Vector3.up, -transform.up, out hit, 25.01f, groundLayermask);

        Debug.Log(hit.transform);
        point2 = hit.point;
        Debug.Log(point2);

        Vector3 angleVector = point2 - point1;

        transform.LookAt(transform.position - angleVector * 5);

        Debug.Log(angleVector);
    }


}
