using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForLeaf : MonoBehaviour
{
    [SerializeField]
    TunnelRotation tunnelRotation;
    [SerializeField]
    Transform holder;

    [SerializeField]
    Camera cam;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Leaf"))
        {
            //cam = Camera.main;
            cam.transform.SetParent(holder);
            cam.transform.localPosition = Vector3.zero;
            cam.transform.localEulerAngles = Vector3.zero;


            Invoke(nameof(ZONA),3f);
            //Destroy(gameObject);
        }
    }

    void ZONA()
    {
        

        tunnelRotation.StartTrip();
    }

}
