using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelRotation : MonoBehaviour
{
    [SerializeField]
    GameObject tunnel;

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

    [SerializeField]
    string fadeOutStateString;

    [SerializeField]
    Animator whiteScreenAnim;

    [SerializeField]
    Animator lsdTunnelEnd;

    [SerializeField]
    Transform lsdestinationCamHolder;
    bool inputBlock = false;

    private void Update()
    {


        tunnel.transform.Rotate(Vector3.up * Time.fixedDeltaTime * RotationForceforce);
    }

    IEnumerator TunnelTripping(float moveDuration, AnimationCurve scalingCurve, AnimationCurve fovCurve, float force, float fovingForce)
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

            tunnel.transform.localScale = tunnel.transform.localScale + (Vector3.up * force * scalingCureveEvaluation);

            Camera.main.fieldOfView = initialFov + (fovCurveEvaluation * fovingForce);
            Debug.Log(Camera.main.fieldOfView);

            if (t >= moveDuration)
            {
                whiteScreen.SetActive(true);
                Camera.main.fieldOfView = 60;
                Camera.main.transform.position = lsdestinationCamHolder.transform.position;
                Camera.main.transform.rotation = lsdestinationCamHolder.transform.rotation;
                Camera.main.gameObject.transform.parent = lsdestinationCamHolder;
            }

            yield return new WaitForFixedUpdate();
        }

        tunnel.SetActive(false);

        whiteScreenAnim.Play(fadeOutStateString);

        yield return null;

        yield return new WaitForSeconds(whiteScreenAnim.GetCurrentAnimatorStateInfo(0).length-0.3f);

        whiteScreen.SetActive(false);

        inputBlock = false;
    }

    [ContextMenu("StartRotate")]
    public void StartTrip()
    {
        if (!inputBlock)
            StartCoroutine(TunnelTripping(moveDuration, scaleCurve, fovCurve, scalingForce, fovForce));
    }

    IEnumerator ConnectToTannel()
    {
        whiteScreen.SetActive(true);

        tunnel.SetActive(true);

        whiteScreenAnim.Play(fadeOutStateString);

        yield return null;

        yield return new WaitForSeconds(whiteScreenAnim.GetCurrentAnimatorStateInfo(0).length - 0.3f);

        whiteScreen.SetActive(false);
    }
}
