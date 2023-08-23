using UnityEngine;

public class Key : MonoBehaviour
{
    public bool HasKey { get; private set; } = false;
    [SerializeField]
    private float rotationSpeed;

    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlaySound();
            HasKey = true;
            gameObject.SetActive(false); // Hide the key when picked up
        }
    }

    private void PlaySound()
    {
        audioManager.PlaySFX(audioManager.coinCollect);
    }
}
