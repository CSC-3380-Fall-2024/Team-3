using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
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
        //detectLayer = LayerMask.NameToLayer("Item");
        //detectPoint = GetComponent<Transform>();
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
                Collider2D collider = Physics2D.OverlapCircle(detectPoint.position, detectRadius, detectLayer);

                if (collider != null)
                {
                    Interactables interactableObject = collider.GetComponent<Interactables>();

                    // If it's an interactable object, call its Interact method
                    if (interactableObject != null)
                    {
                        GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().StartCoroutine(GameObject.Find("ItemSpawner").GetComponent<ItemSpawner>().RespawnWhenDestroyed(interactableObject.gameObject));  //respawn item after one is destroyed
                        interactableObject.Interact();  // Call the Interact method
                    }
                }

                Debug.Log("Interacting with object!");
            }
        }
    }
}
