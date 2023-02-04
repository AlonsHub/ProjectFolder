using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class AttackChicken : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    Transform chicken;

    Animator anim;
    private void Start()
    {
        if (!agent)
            agent = GetComponent<NavMeshAgent>();
        if (!anim)
            anim = GetComponent<Animator>();
    }

    public void WakeUp()
    {

        agent.SetDestination(chicken.position);
        StartCoroutine(nameof(FixTarget));
    }

    
    IEnumerator FixTarget()
    {
        while (true)
        {

            agent.SetDestination(chicken.position);


            yield return new WaitForSeconds(.3f);
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                agent.isStopped = true;
                agent.velocity = Vector3.zero;
            }
            else
            {
                agent.isStopped = false;
                //Pickup and end game
                anim.SetTrigger("PickUp");

            }
        }
    }

    public void EndGame()
    {
        //Load END SCENE
        SceneManager.LoadScene(1);
    }
}
