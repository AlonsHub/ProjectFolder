using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillerKiller : MonoBehaviour
{
    [SerializeField]
     EaterChicken ec;
    //GameObject caterpiller;
    [SerializeField]
    EaterChicken waker;


    private void OnTriggerEnter(Collider collision)
    {
        Character_Warm cw = collision.GetComponent<Character_Warm>();
        if (!cw)
            return;
        //cw.enabled = false;
        //cw.rb.isKinematic = true;

        //call caterpiller
        waker.WakeChicken();

    }
}
