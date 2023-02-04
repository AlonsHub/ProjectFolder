using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafKillBox : MonoBehaviour
{

    [SerializeField]
    CataWaker waker;
    //GameObject caterpiller;


 
    private void OnTriggerEnter(Collider collision)
    {
        LeafController lc = collision.GetComponentInParent<LeafController>();
        if (!lc)
            return;
        lc.enabled = false;
        lc.rb.isKinematic = true;

        //call caterpiller
        waker.WakeCaterpiller();

    }
}
