using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public float moveSpeed = 1.5f; // Speed at which the box moves up and down
    public float maxHeight = 2f; // Maximum height the box can reach
    public float minHeight = 1f; // Minimum height the box can reach
    public GameObject scatteredPiecePrefab; // Prefab of the scattered pieces

    private bool movingUp = true; // Flag to indicate whether the box is moving up or down

    void Update()
    {
        // Move the box up if it's not at the maximum height
        if (movingUp && transform.position.y < maxHeight)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        // Move the box down if it's not at the minimum height
        else if (!movingUp && transform.position.y > minHeight)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        // If the box reaches the maximum or minimum height, toggle the direction
        if (transform.position.y >= maxHeight)
        {
            movingUp = false;
        }
        else if (transform.position.y <= minHeight)
        {
            movingUp = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the box collided with something
        if (collision.gameObject.CompareTag("Player"))
        {
            // Scatter the box into pieces
            Scatter();
            // Destroy the box
            Destroy(gameObject);
        }
    }

    void Scatter()
    {
        // Instantiate scattered pieces of the box
        for (int i = 0; i < 10; i++)
        {
            GameObject scatteredPiece = Instantiate(scatteredPiecePrefab, transform.position, Quaternion.identity);
            // Apply random force to each scattered piece
            scatteredPiece.GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 100f, ForceMode.Impulse);
        }
    }
}