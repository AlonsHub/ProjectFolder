using UnityEngine;

public class SimpleFollowZ : MonoBehaviour
{
    public Transform target;

    public bool isCustomOffset;
    public Vector3 offset;

    public float smoothSpeed = 0.1f;

    float offsetY = .32f;
    [SerializeField]
    float minOffsetY = .23f;
    [SerializeField]
    float maxOffsetY = .5f;

    private void Start()
    {
        // You can also specify your own offset from inspector
        // by making isCustomOffset bool to true
        if (!isCustomOffset)
        {
            offset = transform.position - target.position;
        }
    }

    private void Update()
    {
        offsetY += Input.GetAxis("Mouse Y") * Time.deltaTime;

        offsetY = Mathf.Clamp(offsetY, minOffsetY, maxOffsetY);
        offset.y = offsetY;
    }

    private void LateUpdate()
    {
        SmoothFollow();
    }

    public void SmoothFollow()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 smoothFollow = Vector3.Lerp(transform.position,
        targetPos, smoothSpeed);

        transform.position = smoothFollow;
        transform.LookAt(target);
    }
}