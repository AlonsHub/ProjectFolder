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

    [SerializeField]
    ChickenController cc;

    bool isHardBlock = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Leaf") && !isHardBlock)
        {
            isHardBlock = true;
            //cam = Camera.main;
            cam.transform.SetParent(holder);
            cam.transform.localPosition = Vector3.zero;
            cam.transform.localEulerAngles = Vector3.zero;

            //cc = other.GetComponent<ChickenController>();
            if (cc)
            {
                cc.enabled = true;
            }

            Invoke(nameof(ZONA),1f);
            //Destroy(gameObject);
        }
    }

    void ZONA()
    {
        tunnelRotation.StartTrip();
    }

}
