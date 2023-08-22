using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AudioManager audioManager;
    [SerializeField]
    public GameObject[] lights;
    public GameObject Player;
    public GameObject DestructionEffect;

    [SerializeField]
    private float timerTime = 100f;

    [SerializeField]
    public SpriteRenderer[] sprites;

    [SerializeField]
    private float waittime;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
       
        Invoke(nameof(ActivateLights), waittime);
        Invoke(nameof(desactivateRenderer), waittime);
        Invoke(nameof(killPlayer), timerTime);
    }


    private void ActivateLights()
    {
        foreach (var light in lights)
        {
            light.SetActive(true);
        }

    }

    private void desactivateRenderer()
    {
        foreach (var sprite in sprites)
        {
            sprite.enabled = false;
        }
    }

    private void killPlayer()
    {
        audioManager.PlaySFX(audioManager.Explosion);
        Instantiate(DestructionEffect, Player.transform.position, Quaternion.identity);
        Destroy(Player.gameObject);
    }

  


}
