using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallers;
    [SerializeField]
    private float spawntime;
    private void Start()
    {
        InvokeRepeating(nameof(spawning), 0f, spawntime);
    }
    private void spawning()
    {
        Instantiate(fallers, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
       
    }
}
