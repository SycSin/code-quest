using UnityEngine;

public class FinishLineScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerCrossedFinishLine();
    }

    private void PlayerCrossedFinishLine()
    {
        // Add logic here for what happens when the player crosses the finish line
        Debug.Log("Player crossed the finish line!");
        // For example, you could end the race, display a victory message, etc.
    }
}
