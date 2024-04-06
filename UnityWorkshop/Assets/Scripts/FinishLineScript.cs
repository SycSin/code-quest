using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    private GameObject respawnObject;
    
    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // Find the GameObject with the "Respawn" tag
        respawnObject = GameObject.FindWithTag("StartingPoint");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if respawnObject is null before accessing it
        if (respawnObject != null)
        {
            // Move the player to the respawn point
            other.transform.position = respawnObject.transform.position;
        }
        else
        {
            Debug.LogWarning("No GameObject with the 'Respawn' tag found.");
        }
        PlayerCrossedFinishLine();
    }

    
    private void PlayerCrossedFinishLine()
    {
        // Add logic here for what happens when the player crosses the finish line
        Debug.Log("Player crossed the finish line!");
        // For example, you could end the race, display a victory message, etc.
        
    }
}