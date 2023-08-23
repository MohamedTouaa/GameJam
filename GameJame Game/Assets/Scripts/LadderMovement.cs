using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private Animator animator; // Reference to the Animator component
    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isLadder)
        {
            if (Mathf.Abs(vertical) > 0f)
            {
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            }
            else
            {
                rb.velocity = Vector2.zero; // Stop player's vertical movement
            }

            animator.SetBool("Climbing", true);
        }
        else
        {
            rb.gravityScale = 4f;
            animator.SetBool("Climbing", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
        }
    }
}
