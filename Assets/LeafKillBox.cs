using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafKillBox : MonoBehaviour
{

    [SerializeField]
    GameObject caterpiller;
 
    private void OnTriggerEnter(Collider collision)
    {
        LeafController lc = collision.GetComponentInParent<LeafController>();

        lc.enabled = false;

        //call caterpiller


    }
}
