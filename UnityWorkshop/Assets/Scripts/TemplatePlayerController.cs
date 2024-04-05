using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float forceMagnitude = 10f; // Adjust the force magnitude to control the speed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get input from the horizontal axis (A/D, Left/Right arrow keys)
        float moveVertical = Input.GetAxis("Vertical"); // Get input from the vertical axis (W/S, Up/Down arrow keys)

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        rb.AddForce(movement * forceMagnitude); // Apply the force to the Rigidbody for movement
    }
}