using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField]
    private float waitTime = 10f;
    void Start()
    {
        StartCoroutine(wait());
        this.gameObject.SetActive(true);
    }

    
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
