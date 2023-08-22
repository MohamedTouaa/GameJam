using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{

    public GameObject player;
    public Transform position;
    private AudioManager AudioManager;
    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playsound();
            player.transform.position = position.transform.position;

        }
    }

    private void playsound()
    {
        AudioManager.PlaySFX(AudioManager.teleport);
    }
}
