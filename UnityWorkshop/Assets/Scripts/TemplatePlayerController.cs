using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float forceMagnitude = 10f; // Adjust the force magnitude to control the speed
    public float slowedForceMagnitude = 2f; // Adjust the slowed force magnitude after collision
    public float speedupForceMagnitude = 80f; // Adjust the speedup force magnitude after collision
    public float duration = 2f; // Duration of slowdown / speedup after collision

    private Vector3 checkpointPosition;

    private Rigidbody rb;
    private bool isSlowed = false; // Flag to indicate if the sphere is currently slowed down

    void Start()
    {
    	checkpointPosition = GameObject.FindWithTag("Respawn").transform.position; // Store the position of the latest checkpoint
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get input from the horizontal axis (A/D, Left/Right arrow keys or left joystick on Xbox controller)
        float moveVertical = Input.GetAxis("Vertical"); // Get input from the vertical axis (W/S, Up/Down arrow keys or left joystick on Xbox controller)

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Apply force magnitude based on whether the sphere is slowed down or not
        float currentForceMagnitude = isSlowed ? slowedForceMagnitude : forceMagnitude;

        rb.AddForce(movement * currentForceMagnitude); // Apply the force to the Rigidbody for movement
    }
    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void OnCollisionEnter(Collision collision)
    {
        // Check if the sphere collided with an object tagged as "collectible"
        if (collision.gameObject.CompareTag("Collectible"))
        {
            // Randomly decide whether to slow down or speed up
            bool shouldSlowdown = Random.Range(0, 2) == 0; // 50% chance to slow down

            // Start slowing down or speeding up the sphere
            if (shouldSlowdown)
            {
                Debug.Log("Slow down");
                StartSlowdown();
                // Play random collision sound effect
               
                audioManager.PlaySFXSound(audioManager.collisionsFxSFart);
            }
            else
            {
                Debug.Log("Speed up");
                StartSpeedup();
                audioManager.PlaySFXSound(audioManager.collisionsFxSMaxls);
            }
        }
        // Check if the sphere collided with an object tagged as "DeathArea"
        if (collision.gameObject.CompareTag("DeathArea"))
        {
            // Set the player's position to the latest checkpoint's position
            transform.position = checkpointPosition;
			forceMagnitude = 1f; // Adjust the force magnitude to control the speed	
            Debug.Log("Player respawned at checkpoint " + checkpointPosition + ".");
        }
    }

	void OnTriggerEnter(Collider collision)
	{
        // Check if the sphere collided with an object tagged as "Checkpoint"
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            checkpointPosition = collision.transform.position;
            Debug.Log("Checkpoint " + checkpointPosition + " crossed.");
        }
	}

    void StartSlowdown()
    {
        // Slow down the sphere
        isSlowed = true;
        // Restore normal speed after a certain duration
        Invoke("StopSlowdown", duration);
    }

    void StartSpeedup()
    {
        // Speed up the sphere
        float currentForceMagnitude = isSlowed ? slowedForceMagnitude : forceMagnitude;
        rb.velocity *= (speedupForceMagnitude / currentForceMagnitude);
        // Restore normal speed after a certain duration
        Invoke("StopSpeedup", duration);
    }

    void StopSlowdown()
    {
        // Restore normal speed
        isSlowed = false;
    }

    void StopSpeedup()
    {
        // Restore normal speed
        float currentForceMagnitude = isSlowed ? slowedForceMagnitude : forceMagnitude;
        rb.velocity *= (currentForceMagnitude / speedupForceMagnitude);
    }
}
