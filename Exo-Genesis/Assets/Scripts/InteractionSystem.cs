using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    public PlayerMovement player;

    public Transform detectPoint;
    private const float detectRadius = 0.2f;
    public LayerMask detectLayer;

    private void Start()
    {
        player = GetComponent<PlayerMovement>();
    }


    bool InteractInput()
    {
        return Input.GetKeyDown(player.interactionKey);
    }

    bool ObjectInRange()
    {
        return Physics2D.OverlapCircle(detectPoint.position, detectRadius, detectLayer);
    }


    private void Update()
    {
        if (ObjectInRange())
        {
            //Debug.Log("in range");
            if (InteractInput())
            {
                Debug.Log("interacting");
            }
        }
    }
}
