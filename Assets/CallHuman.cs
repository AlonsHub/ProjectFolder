using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHuman : MonoBehaviour
{
    [SerializeField]
    AttackChicken ac;

    private void Start()
    {
        if(!ac)
        ac = GetComponent<AttackChicken>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(ac && other.CompareTag("Chicken"))
        {
            ac.WakeUp();
        }
    }
}
