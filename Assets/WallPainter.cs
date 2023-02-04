using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPainter : MonoBehaviour
{
    [SerializeField]
    Renderer rend;
    [SerializeField]
    float totalTime;

    //void Start()
    //{
    //    mat = GetComponent<Renderer>().material;
    //}
    [SerializeField]
    Animator anim;

    public void StartShiftToOne()
    {
        anim.SetTrigger("END");
        //StartCoroutine(nameof(GradualDraw));
    }

    IEnumerator GradualDraw()
    {
        float t = 0;
        while (t <= totalTime)
        {
            t += Time.deltaTime;
            

            rend.material.SetFloat("Vector1", -(t));
            yield return null;
        }
    }
}
