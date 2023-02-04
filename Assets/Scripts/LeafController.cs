using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float waveLength;
    [SerializeField]
    float freq;

    [SerializeField]
    float upMod;

    //By right_velocity, gain some up_velocity, but lose right_velocity?
    float x;
    Vector3 _addedVel;
    float zrot;
    public Rigidbody rb;
    bool go;
    [SerializeField]
    Transform lookAtMe;
    [SerializeField]
    Transform leaf;
    void Start()
    {
        if (!rb)
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Rot and Added Vel calc

        float sin = Mathf.Cos(Time.time * freq);

        _addedVel = sin * waveLength * Vector3.forward;
        
        zrot = -sin * waveLength * 10f * Time.deltaTime;
        transform.rotation =Quaternion.Euler( new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zrot));
        //if (Mathf.Sin(sin) > .88f)
        //    _addedVel += upMod * Vector3.up / sin;

        #endregion

         x = -Input.GetAxis("Horizontal")* moveSpeed;

        //leaf.LookAt(lookAtMe);
    }

    private void FixedUpdate()
    {
        rb.AddForce(_addedVel);
        rb.AddForce(x * Vector3.forward);
    }
}
