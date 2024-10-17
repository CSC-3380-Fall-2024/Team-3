using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target1;
    private Transform target2;
    private GameController gameController;
    public float padding = 2f; // Space to keep between players and screen edges

    void Start()
    {
        target1 = GameObject.Find("Player1").transform;
        target2 = GameObject.Find("Player2").transform;
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    void Update()
    {
        // Calculate the average position between the two players
        Vector3 averagePosition = (target1.position + target2.position) / 2;

        // Calculate the distance between the two players
        float distance = Vector3.Distance(target1.position, target2.position);

        // Clamp the distance to the minimum and maximum
        if (distance < gameController.minDistance)
        {
            Vector3 direction = (target2.position - target1.position).normalized;
            averagePosition = target1.position + direction * (gameController.minDistance / 2);
        }
        else if (distance > gameController.maxDistance)
        {
            Vector3 direction = (target2.position - target1.position).normalized;
            averagePosition = target1.position + direction * (gameController.maxDistance / 2);
        }

        // Set the camera position
        transform.position = new Vector3(averagePosition.x, averagePosition.y, transform.position.z);

        // Optional: Adjust camera size or orthographic size if needed
        Camera cam = GetComponent<Camera>();
        if (cam != null)
        {
            // Adjust the orthographic size based on the distance and padding
            cam.orthographicSize = Mathf.Max((distance + padding) / cam.aspect / 2, padding);
        }
    }
}

