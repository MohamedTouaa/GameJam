using UnityEngine;

public class Key : MonoBehaviour
{
    public bool HasKey { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HasKey = true;
            gameObject.SetActive(false); // Hide the key when picked up
        }
    }
}
