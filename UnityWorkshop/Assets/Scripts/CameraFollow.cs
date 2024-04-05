using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera should follow
    public Vector3 offset; // The offset from the target position
    public float smoothSpeed = 0.125f; // Smoothing speed
    public bool lookAtTarget = true; // Whether the camera should rotate to look at the target

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        if (lookAtTarget)
        {
            transform.LookAt(target);
        }
    }
}