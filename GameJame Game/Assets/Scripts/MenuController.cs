using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
   public Rigidbody2D rb;
    [SerializeField]
    private Transform GroundCheck;
    [SerializeField]
    private LayerMask GroundLayer;


    [SerializeField]
    private float jumpingForce = 16f, speed = 8f;
    private float horizontal;
    private bool isFacingRight;

   

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingForce);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y> 0f)
        {
            rb.velocity =new Vector2(rb.velocity.x, 0.5f * jumpingForce );
        }

        flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed , rb.velocity.y);
    }



    private void flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }
}
