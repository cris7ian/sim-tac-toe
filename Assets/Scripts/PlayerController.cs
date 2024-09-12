using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static PlayerController activePlayer;
    public float speed = 10;
    public float jumpForce = 5.0f; // Add a public variable for jump force
    public GameObject marker;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private bool isGrounded; // Add a variable to check if the player is grounded
    private PlayerInput playerInput;
    private bool hovereded;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true; // Set isGrounded to true when the game starts
        playerInput = GetComponent<PlayerInput>();
        playerInput.enabled = false;
    }

    void OnMouseOver()
    {
        if (playerInput.enabled) return;
        hovereded = true;
    }

    void OnMouseExit()
    {
        hovereded = false;
        marker.SetActive(false);
    }

    void OnMouseUp()
    {
        // Set the clicked object as the active player
        if (activePlayer != null)
        {
            activePlayer.playerInput.enabled = false; // Disable the previous active player's input
        }

        activePlayer = this; // Set this player as active
        playerInput.enabled = true; // Enable input for the clicked object
    }

    void OnMove(InputValue movementValue)
    {
        if (!playerInput.enabled) return;
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnReset()
    {
        playerInput.enabled = false;
        activePlayer = null;
    }

    void OnJump()
    {
        if (!playerInput.enabled) return;
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isGrounded = false; // Set isGrounded to false when jumping
        }
    }

    void OnTriggerEnter(Collider other)
    {

    }

    void FixedUpdate()
    {
        if (hovereded)
        {
            marker.SetActive(true);
            marker.transform.position = transform.position;
        }
        if (!playerInput.enabled) return;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
}
