using UnityEngine;

public class Key : MonoBehaviour
{
    public bool HasKey { get; private set; } = false;
    [SerializeField]
    private float rotationSpeed;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HasKey = true;
            gameObject.SetActive(false); // Hide the key when picked up
        }
    }
}
