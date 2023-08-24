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
    public GameManager gamemanger;



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
            this.gameObject.SetActive(false);
            gamemanger.loadscene();
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




}
