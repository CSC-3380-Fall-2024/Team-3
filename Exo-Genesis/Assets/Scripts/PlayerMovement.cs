using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    public float moveSpeed = 20f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spr;


    [Header("KeyCodes For Player1")]
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode interactionKey = KeyCode.LeftControl;
    public KeyCode subInteractionKey = KeyCode.CapsLock;

    [Header("KeyCodes For Player2")]
    public KeyCode leftKey2 = KeyCode.LeftArrow;
    public KeyCode rightKey2 = KeyCode.RightArrow;
    public KeyCode upKey2 = KeyCode.UpArrow;
    public KeyCode downKey2 = KeyCode.DownArrow;
    public KeyCode interactionKey2 = KeyCode.RightControl;
    public KeyCode subInteractionKey2 = KeyCode.Slash;

    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canMoveUp = true;
    public bool canMoveDown = true;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        ChangeControls();

    }
    private void ChangeControls()
    {
        if (gameObject.name == "Player2")
        {
            leftKey = leftKey2;
            rightKey = rightKey2;
            upKey = upKey2;
            downKey = downKey2;
            //not gonna be used for now
            interactionKey = interactionKey2;
            subInteractionKey = subInteractionKey2;
        }
    }

    public void MovementInput()
    {
        moveInput = Vector2.zero;
        if (Input.GetKey(leftKey) && canMoveLeft)
        {
            moveInput.x = -1f;
            spr.flipX = moveInput.x * -1 < 0;
        }
        else if (Input.GetKey(rightKey) && canMoveRight)
        {
            moveInput.x = 1f;
            spr.flipX = moveInput.x * -1 < 0;
        }
        else
        {
            moveInput.x = 0f;
        }
        if (Input.GetKey(downKey) && canMoveDown)
        {
            moveInput.y = -1f;
        }
        else if (Input.GetKey(upKey) && canMoveUp)
        {
            moveInput.y = 1f;
        }
        else
        {
            moveInput.y = 0f;
        }
        rb.velocity = moveInput * moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            MovementInput();
        }

    }
}
