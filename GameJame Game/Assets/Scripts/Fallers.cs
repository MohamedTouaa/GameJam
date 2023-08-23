using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallers : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField]
    private float reset = 2f, audioDistance = 5f;
    private Transform PlayerPosition;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        PlayerPosition= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();   
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

            if (Vector2.Distance(this.transform.position, PlayerPosition.position) <= audioDistance)
            {
                Playsound();
            }
            Destroy(gameObject);
        }
    }
    private void Playsound()
    {
        audioManager.PlaySFX(audioManager.Explosion);
    }



}
