using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForLeaf : MonoBehaviour
{
    [SerializeField]
    LeafController lc;

    bool doUpdate;
    private Vector3 offset;

    public void TurnOnLeaf()
    {
        doUpdate = true;
        lc.enabled = true;

        lc.rb.isKinematic = false;


            //offset = transform.position - lc.transform.position;
    }

    //private void Update()
    //{
    //    if(doUpdate)
    //    {
    //        SmoothFollow();
    //        Debug.Log("call smooth follow");
    //    }
    //}

    //public void SmoothFollow()
    //{
    //    Vector3 targetPos = lc.transform.position + offset;
    //    Vector3 smoothFollow = Vector3.Lerp(transform.position,
    //    targetPos, .9f);

    //    transform.position = smoothFollow;
    //    //transform.LookAt(lc.transform);
    //}
}
