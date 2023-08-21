using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject[] lights;
    [SerializeField]
    private float waittime;
    private int index;
    void Start()
    {
        Invoke(nameof(ActivateLights), waittime);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void ActivateLights()
    {
        foreach (var light in lights)
        {
            light.SetActive(true);
        }
        
    }
}
