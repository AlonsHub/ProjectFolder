using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Warm : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;

    [SerializeField]
    LayerMask groundLayermask;

    [SerializeField]
    Animator anim;

    [SerializeField]
    float gravity;

    [Header("Forward")]

    [Space]

    [SerializeField]
    float forwardforce;

    [SerializeField]
    float forwardMoveDuration;

    [SerializeField]
    AnimationCurve forwardAnimationCurve;

    [Header("Backward")]

    [Space]

    [SerializeField]
    float backwardforce;

    [SerializeField]
    float backwardMoveDuration;

    [SerializeField]
    AnimationCurve backwardAnimationCurve;


    bool inputBlock = false;

    private void Update()
    {
        //if (!GroundCheck())
        //    return;

        if (inputBlock)
            return;



        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Movement(forwardMoveDuration, transform.forward,forwardAnimationCurve,forwardforce));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Movement(backwardMoveDuration, -transform.forward, backwardAnimationCurve,backwardforce));
        }
    }

    IEnumerator Movement(float moveDuration,Vector3 movementVector,AnimationCurve relevantAnimationCurve,float force)
    {
        inputBlock = true;

        float startTime = Time.time;
        float t = 0;

        while (t < moveDuration)
        {
            t += Time.deltaTime;

            float cureveEvaluation = relevantAnimationCurve.Evaluate(t / moveDuration);
 
            Vector3 frameMovement = movementVector * (force * cureveEvaluation);

            characterController.Move(frameMovement);

            yield return new WaitForFixedUpdate();
        }

        inputBlock = false;
    }

    bool GroundCheck()
    {
        bool value = Physics.Raycast(transform.position, -transform.up, 0.01f, groundLayermask);
        Debug.Log(value);

        if (!value)
        {
            characterController.Move(-transform.up);
            Debug.Log(-transform.up);
            Debug.Log(gravity);
            Debug.Log(-transform.up);
        }

        return value;
    }

}
