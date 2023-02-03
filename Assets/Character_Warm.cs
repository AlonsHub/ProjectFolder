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

    private void Awake()
    {
        characterController.enabled = true;
    }

    private void Update()
    {
        GroundAngle();

        if (!GroundCheck())
            return;

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
            Debug.Log(frameMovement.ToString());
            characterController.Move(frameMovement);

            yield return new WaitForFixedUpdate();
        }

        inputBlock = false;
    }

    bool GroundCheck()
    {
        bool value = Physics.Raycast(transform.position, -transform.up , 1.1f, groundLayermask);
        Debug.Log(value);

        if (!value)
        {
            characterController.Move(-transform.up * gravity * Time.fixedDeltaTime);
            Debug.Log(-transform.up);
            Debug.Log(gravity);
            Debug.Log(-transform.up);
        }

        

        return value;
    }

    void GroundAngle()
    {

        Vector3 point1, point2;

        RaycastHit hit;

        Physics.Raycast(transform.position + transform.forward * 0.5f + Vector3.up, -transform.up, out hit, 4f, groundLayermask);
        Debug.Log(hit.transform);
        point1 = hit.point;

        Debug.Log(point1);
        Physics.Raycast(transform.position -transform.forward * 0.5f + Vector3.up, -transform.up, out hit, 4f, groundLayermask);

        Debug.Log(hit.transform);
        point2 = hit.point;
        Debug.Log(point2);

        Vector3 angleVector = point2 - point1;

        transform.LookAt(transform.position - angleVector * 5);

        Debug.Log(angleVector);
    }

}
