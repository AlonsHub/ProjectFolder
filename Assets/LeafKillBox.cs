using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafKillBox : MonoBehaviour
{
 
    private void OnTriggerStay(Collider collision)
    {
        LeafController lc = collision.GetComponent<LeafController>();


    }
}
