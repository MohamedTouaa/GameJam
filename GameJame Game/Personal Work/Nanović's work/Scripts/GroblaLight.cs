using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class GroblaLight : MonoBehaviour
{
    private Light2D light;
    [SerializeField]
    private float waitTime = 10f,lightIntensity = 0f;
    private void Awake()
    {
        light = GetComponent<Light2D>();
    }
    void Start()
    {

        Invoke(nameof(chaneLight), waitTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void chaneLight()
    {
        light.intensity = lightIntensity;
    }


}
