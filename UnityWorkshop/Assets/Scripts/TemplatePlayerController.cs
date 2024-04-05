using UnityEngine;
using System.Collections.Generic;

public class SphereRoller : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the sphere moves
    public float rollSpeed = 250f; // Speed at which the sphere rolls

    void Update()
    {
        if(Input.GetKey("space"))
        {
            moveSpeed += 0.125f;
        }
        // Get input from the keyboard
        float moveHorizontal = Input.GetAxis("Horizontal"); // Maps to A/D or Left Arrow/Right Arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // Maps to W/S or Up Arrow/Down Arrow keys

        // Calculate movement and rotation
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * moveSpeed * Time.deltaTime;
        Vector3 rotation = new Vector3(moveVertical, 0.0f, -moveHorizontal) * rollSpeed * Time.deltaTime;

        // Apply movement and rotation to the sphere
        transform.Translate(movement, Space.World); // Move the sphere
        transform.Rotate(rotation, Space.World); // Rotate the sphere to simulate rolling
    }
}