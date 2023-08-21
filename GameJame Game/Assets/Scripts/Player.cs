using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fallers") || collision.gameObject.CompareTag("FireGround"))
        {
            Destroy(this.gameObject);
        }
    }
}
