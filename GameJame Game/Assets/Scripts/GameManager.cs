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
        audioManager.PlaySFX(audioManager.countdown);
        Invoke(nameof(ActivateLights), waittime);
        Invoke(nameof(desactivateRenderer), waittime);  
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
        foreach(var sprite in sprites)
        {
            sprite.enabled = false;
        }
    }
    

}
