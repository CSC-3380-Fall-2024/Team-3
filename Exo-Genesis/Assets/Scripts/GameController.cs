using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float minDistance = 7f;
    public float maxDistance = 20f;

    public GameObject player1;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        // Check horizontal distance
        if (player1.transform.position.x - player2.transform.position.x >= maxDistance)
        {
            player2.GetComponent<PlayerMovement>().canMoveLeft = false;
            player1.GetComponent<PlayerMovement>().canMoveRight = false;
        }
        else
        {
            player2.GetComponent<PlayerMovement>().canMoveLeft = true;
            player1.GetComponent<PlayerMovement>().canMoveRight = true;
        }

        if (player2.transform.position.x - player1.transform.position.x >= maxDistance)
        {
            player1.GetComponent<PlayerMovement>().canMoveLeft = false;
            player2.GetComponent<PlayerMovement>().canMoveRight = false;
        }
        else
        {
            player1.GetComponent<PlayerMovement>().canMoveLeft = true;
            player2.GetComponent<PlayerMovement>().canMoveRight = true;
        }

        // Check vertical distance
        if (player1.transform.position.y - player2.transform.position.y >= maxDistance)
        {
            player2.GetComponent<PlayerMovement>().canMoveDown = false;
            player1.GetComponent<PlayerMovement>().canMoveUp = false;
        }
        else
        {
            player2.GetComponent<PlayerMovement>().canMoveDown = true;
            player1.GetComponent<PlayerMovement>().canMoveUp = true;
        }

        if (player2.transform.position.y - player1.transform.position.y >= maxDistance)
        {
            player1.GetComponent<PlayerMovement>().canMoveDown = false;
            player2.GetComponent<PlayerMovement>().canMoveUp = false;
        }
        else
        {
            player1.GetComponent<PlayerMovement>().canMoveDown = true;
            player2.GetComponent<PlayerMovement>().canMoveUp = true;
        }
    }
}
