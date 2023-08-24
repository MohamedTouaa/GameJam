using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private float waitTime = 5f;
    public PlayerMovement movement;
    public GameObject explosion;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private GameObject heealthBar;
    private HeealthBar Thehealth;




    AudioManager audioManager;




    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        heealthBar = GameObject.FindGameObjectWithTag("HealthBar");
        Thehealth = heealthBar.GetComponent<HeealthBar>();



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
        health--;
        audioManager.PlaySFX(audioManager.Death);
        if (health == 0)
        {
            Thehealth.destroyHealth();
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            sprite.enabled = false;
            StartCoroutine(loadscene());


        }
        else
        {

            Thehealth.destroyHealth();
            StartCoroutine(wait());
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
        this.transform.position = new Vector2(-53.95f, -3.19f);
        sprite.enabled = true;
        movement.enabled = true;
    }

    private IEnumerator loadscene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 7)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(6);
           
        }

        else if (SceneManager.GetActiveScene().buildIndex ==2 || SceneManager.GetActiveScene().buildIndex == 4)
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(2);

        }
    }



}
