using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool isFlapping = false;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;


    [SerializeField]
    private float maxAirTime= 3f;
    [SerializeField]
    private float currentAirTime= 0;

    bool canAir = true;

    Animator anim;
    [SerializeField]
    private float groundCheckHeight;
    [SerializeField]
    private LayerMask groundLayermask;

    private void Start()
    {
        if(!controller)
        controller = gameObject.GetComponent<CharacterController>();
        if (!anim)
            anim = GetComponent<Animator>();
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        groundedPlayer = GroundCheck();
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        //}
        
        Vector3 move = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
       
            anim.SetBool("Walk", move.magnitude > 0f);
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }


        float drag = 1;
        // Changes the height position of the player..
        if (Input.GetButton("Jump"))
        {
            if (groundedPlayer)
            {
                anim.SetTrigger("Jump");
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            else if(playerVelocity.y < 0)
            {
                //currentAirTime += Time.deltaTime;
                drag = 3f;
                
            }
        }

        if (!groundedPlayer)
        {
            playerVelocity.y += (gravityValue / drag) * Time.deltaTime;

            anim.SetBool("InAir", Input.GetButton("Jump"));

        }
        //else
        //{
        //    isFlapping = false;
        //    anim.SetBool("Flap", false);

        //}

        controller.Move(playerVelocity * Time.deltaTime);
    }

    IEnumerator CoolDownAir()
    {
        canAir = false;
        anim.SetBool("InAir", false);
        yield return new WaitForSeconds(maxAirTime);
        canAir = true;
    }

    bool GroundCheck()
    {
        bool value = Physics.Raycast(transform.position, -transform.up, groundCheckHeight, groundLayermask);
        Debug.Log(value);



        return value;
    }
}