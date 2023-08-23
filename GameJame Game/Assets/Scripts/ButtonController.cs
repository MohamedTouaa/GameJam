using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door;         // Reference to the door GameObject
    public float interactionRange = 2f;  // The range at which the player can interact with the button
    public Sprite pressedSprite;    // The sprite to use when the button is pressed
    public Sprite releasedSprite;   // The sprite to use when the button is released

    private SpriteRenderer spriteRenderer;
    private bool isPressed = false;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Check if the player is within interaction range and presses the "E" key
        if (IsPlayerInRange() && Input.GetKeyDown(KeyCode.E))
        {
            playSound();
            isPressed = !isPressed;
            spriteRenderer.sprite = isPressed ? pressedSprite : releasedSprite;
            door.GetComponent<DoorController>().ToggleDoor();  // Call the ToggleDoor function in the DoorController script
        }
    }

    private bool IsPlayerInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Get the player's position
            Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);

            // Get the button's position
            Vector2 buttonPosition = new Vector2(transform.position.x, transform.position.y);

            // Calculate the distance between the player and the button
            float distance = Vector2.Distance(playerPosition, buttonPosition);

            // Check if the distance is within the interaction range
            return distance <= interactionRange;
        }

        return false;
    }

    private void playSound()
    {
        audioManager.PlaySFX(audioManager.button);
    }

}
