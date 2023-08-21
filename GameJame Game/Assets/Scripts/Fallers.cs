using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallers : MonoBehaviour
{
    [SerializeField]
    private float rotationspeed = 30f;
    private void Update()
    {
        transform.eulerAngles += new Vector3(0f, 0f, rotationspeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            Debug.Log("it works");
            Destroy(this.gameObject);
        }
    }


}
