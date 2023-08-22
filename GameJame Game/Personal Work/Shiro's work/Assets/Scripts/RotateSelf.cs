using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    public float rotationSpeed = 30f;  // Speed of rotation in degrees per second

    private void Update()
    {
        // Rotate the GameObject around its own axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
