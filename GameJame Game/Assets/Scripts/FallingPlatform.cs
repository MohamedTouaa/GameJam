using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFalling = false;

    public float fallSpeed = 5.0f;         // Adjust the falling speed as needed
    public float delayBeforeFalling = 2.0f; // Delay in seconds before falling
    public LayerMask groundLayer;          // Layer mask for the ground layer

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static; // Platform starts as static
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isFalling) // You can change the tag as needed
        {
            isFalling = true;
            Invoke("StartFalling", delayBeforeFalling);
        }
    }

    private void StartFalling()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // Change to dynamic so it falls
        rb.velocity = new Vector2(0, -fallSpeed); // Set the downward velocity
        rb.freezeRotation = true; // Lock rotation around Z-axis
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isFalling && groundLayer == (groundLayer | (1 << other.gameObject.layer)))
        {
            Destroy(gameObject); // Destroy the platform when it hits the ground
        }
    }
}
