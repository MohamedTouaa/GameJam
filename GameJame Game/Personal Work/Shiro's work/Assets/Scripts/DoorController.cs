using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen = false;  // Track the door state

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        gameObject.SetActive(!isOpen); // Toggle the visibility of the door GameObject
    }
}
