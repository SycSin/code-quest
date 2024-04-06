using UnityEngine;
using UnityEngine.InputSystem;

public class SphereMovement : MonoBehaviour
{
    public float forceMagnitude = 10f;
    public float slowedForceMagnitude = 2f;
    public float speedupForceMagnitude = 80f;
    public float duration = 2f;

    private Vector3 checkpointPosition;
    private Rigidbody rb;
    private bool isSlowed = false;
    private Vector2 moveInput;
	private AudioManager audioManager;

    void Start()
    {
        checkpointPosition = GameObject.FindWithTag("StartingPoint").transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0.0f, moveInput.y);
        float currentForceMagnitude = isSlowed ? slowedForceMagnitude : forceMagnitude;
        rb.AddForce(movement * currentForceMagnitude);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            bool shouldSlowdown = Random.Range(0, 2) == 0; // 50% chance to slow down

            if (shouldSlowdown)
            {
                Debug.Log("Slow down");
                StartSlowdown();
                audioManager.PlaySFXSound(audioManager.collisionsFxSFart);
            }
            else
            {
                Debug.Log("Speed up");
                StartSpeedup();
                audioManager.PlaySFXSound(audioManager.collisionsFxSMaxls);
            }
        }

        if (collision.gameObject.CompareTag("DeathArea"))
        {
            transform.position = checkpointPosition;
            Debug.Log("Player respawned at checkpoint " + checkpointPosition + ".");
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            checkpointPosition = collision.transform.position;
            Debug.Log("Checkpoint " + checkpointPosition + " crossed.");
        }
    }

    void StartSlowdown()
    {
        isSlowed = true;
        Invoke("StopSlowdown", duration);
    }

    void StartSpeedup()
    {
        float currentForceMagnitude = isSlowed ? slowedForceMagnitude : forceMagnitude;
        rb.velocity *= (speedupForceMagnitude / currentForceMagnitude);
        Invoke("StopSpeedup", duration);
    }

    void StopSlowdown()
    {
        isSlowed = false;
    }

    void StopSpeedup()
    {
        float currentForceMagnitude = isSlowed ? slowedForceMagnitude : forceMagnitude;
        rb.velocity *= (currentForceMagnitude / speedupForceMagnitude);
    }
}
