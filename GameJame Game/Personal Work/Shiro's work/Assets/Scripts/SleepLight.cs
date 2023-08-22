using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class SleepLight : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 10f;
    private Light2D light2D;

    private void Awake()
    {
        light2D = GetComponent<Light2D>();
    }
    private void Start()
    {
        Invoke(nameof(Turnoff), waitTime);
    }
   private void Turnoff()
    {
        light2D.intensity = 0f;
    }
}
