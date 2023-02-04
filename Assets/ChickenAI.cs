using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenAI : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayermask;
    NavMeshAgent agent;
    private void Start()
    {
        if (!agent)
            agent = GetComponent<NavMeshAgent>();

        
    }

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
        GroundAngle();
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
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
