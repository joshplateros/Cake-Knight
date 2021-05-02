using UnityEngine;

public class CameraFollowNew : MonoBehaviour
{
    public static CameraFollowNew inst;
    private void Awake() {
        inst = this;
    }
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate() {
        Vector3 desiredPosition = target.position + offset;
        //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // transform.position = smoothedPosition;
        transform.position = desiredPosition;

        transform.LookAt(target);
    }
}
