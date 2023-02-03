using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelRotation : MonoBehaviour
{
    [SerializeField]
    float moveDuration;

    [SerializeField]
    float RotationForceforce;


    [SerializeField]
    float scalingForce;

    [SerializeField]
    AnimationCurve scaleCurve;

    [SerializeField]
    AnimationCurve fovCurve;

    [SerializeField]
    float fovForce;

    [SerializeField]
    GameObject whiteScreen;
   

    bool inputBlock = false;

    private void Update()
    {


        transform.Rotate(Vector3.up * Time.fixedDeltaTime * RotationForceforce);
    }

    IEnumerator TunnelMovement(float moveDuration, AnimationCurve scalingCurve,AnimationCurve fovCurve, float force,float fovingForce)
    {
        float initialFov = Camera.main.fieldOfView;
        inputBlock = true;

        float startTime = Time.time;
        float t = 0;

        while (t < moveDuration)
        {
            t += Time.deltaTime;

            float scalingCureveEvaluation = scalingCurve.Evaluate(t / moveDuration);
            float fovCurveEvaluation = fovCurve.Evaluate(t / moveDuration);

            transform.localScale = transform.localScale + (Vector3.up * force * scalingCureveEvaluation);

            Camera.main.fieldOfView = initialFov + (fovCurveEvaluation * fovingForce);
            Debug.Log(Camera.main.fieldOfView);

            if(t>=moveDuration)
            whiteScreen.SetActive(true);

            yield return new WaitForFixedUpdate();
        }


        inputBlock = false;
    }
    
    [ContextMenu("StartRotate")]
    public void StartRotate()
    {
        StartCoroutine(TunnelMovement(moveDuration, scaleCurve, fovCurve, scalingForce, fovForce));
    }
}
