using UnityEngine;

public class DroneCameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera should follow (the sphere)
    public Vector3 offset = new Vector3(0, 5, -10); // Offset from the target. Adjust for desired distance and height
    public float followSpeed = 10f; // How quickly the camera catches up to the target

    private void FixedUpdate()
    {
        // Target position with offset
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Optionally, make the camera look at the target.
        // Remove or comment out this line if you don't want the camera to rotate at all.
        transform.LookAt(target);
    }
}