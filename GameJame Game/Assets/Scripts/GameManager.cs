using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] lights;

    [SerializeField]
    public SpriteRenderer[] sprites;

    [SerializeField]
    private float waittime;

    void Start()
    {
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
