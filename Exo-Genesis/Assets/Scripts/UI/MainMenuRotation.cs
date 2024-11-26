using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Speed of rotation (degrees per second)

    void Update()
    {
        // Rotate the object around the Z-axis (2D rotation)
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}

