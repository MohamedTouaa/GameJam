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
    public GameObject explosion;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
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
        
        
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            StartCoroutine(wait());
            health--;
              

        }
    }

    private void activateMovement()
    {
        movement.enabled = true;
    }

  private IEnumerator wait()
    {
        rb.velocity = Vector2.zero;
        movement.enabled = false;
        sprite.enabled = false;
        Instantiate(explosion, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        this.transform.position = spawnPosition.position;
        sprite.enabled = true;
        movement.enabled = true;
    }


}
