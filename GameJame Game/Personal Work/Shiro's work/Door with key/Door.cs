using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    public GameObject key; // Reference to the key GameObject
    public GameObject door; // Reference to the door GameObject
    private bool isOpen = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOpen && collision.CompareTag("Player") && key.GetComponent<Key>().HasKey)
        {
            isOpen = true;
            door.SetActive(false); // Hide the door when opened
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOpen && collision.CompareTag("Player"))
        {
            isOpen = false;
            door.SetActive(true); // Show the door when closed
        }
    }
}
