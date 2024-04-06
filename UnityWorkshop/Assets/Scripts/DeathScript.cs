using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class DeathScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // If the object colliding with the death area has a specific tag, e.g., "Player"
        // You can remove the tag check if you want any collision to trigger the reset
        if (other.gameObject.CompareTag("Player"))
        {
            RestartScene();
        }
    }

    // Optional: Use this if your death area is set as a trigger
    private void OnTriggerEnter(Collider other)
    {
        // If the object triggering the death area has a specific tag, e.g., "Player"
        if (other.CompareTag("Player"))
        {
            RestartScene();
        }
    }

    void RestartScene()
    {
        // Reloads the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}