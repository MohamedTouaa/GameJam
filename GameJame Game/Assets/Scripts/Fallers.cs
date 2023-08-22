using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallers : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField]
    private float reset = 2f;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    [SerializeField]
    private float rotationspeed = 30f;
    private void Update()
    {
        transform.eulerAngles += new Vector3(0f, 0f, rotationspeed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {


            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Playmusic());
        }
;
    }
    private IEnumerator Playmusic()
    {
        audioManager.PlaySFX(audioManager.Explosion);
        yield return new WaitForSeconds(reset);
    }

}
