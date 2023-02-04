using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWall : MonoBehaviour
{
    [SerializeField]
    float windforce;
    private void OnTriggerStay(Collider collision)
    {
        collision.GetComponentInParent<Rigidbody>().AddForce(transform.up * windforce);
    }
    
}
