using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}