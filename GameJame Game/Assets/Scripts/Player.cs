using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private float waitTime = 5f;
    public PlayerMovement movement;
    public Transform spawnPosition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fallers") || collision.gameObject.CompareTag("FireGround"))
        {
            Damage();
        }
    }
    private void Start()
    {
        Invoke(nameof(activateMovement), waitTime);
    }


    private void Damage()
    {
        health--;
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.transform.position = spawnPosition.position;
        }
    }

    private void activateMovement()
    {
        movement.enabled = true;
    }


}
