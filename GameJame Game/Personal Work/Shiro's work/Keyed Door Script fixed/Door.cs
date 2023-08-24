using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject key; // Reference to the key GameObject
    public GameObject door; // Reference to the door GameObject
    private bool isOpen = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isOpen && collision.gameObject.CompareTag("Player") && key.GetComponent<Key>().HasKey)
        {
            isOpen = true;
            door.SetActive(false); // Hide the door when opened
        }
    }

}
