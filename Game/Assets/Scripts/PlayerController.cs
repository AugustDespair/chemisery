using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 50f;
    public float playerFeetRadius = 0.2f;
    private float direction = 0f;
    private bool isGrounded = false;
    private float localScaleX = 1;
    private Animator playerAnimator;

    public Transform playerFeet;
    public LayerMask groundLayer;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        //Get reference to rigidbody component for left right movement and jumping
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get direction keypress from user
        direction = Input.GetAxisRaw("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(direction));

        //Move the player
        if (direction != 0)
        {
            playerRb.velocity = new Vector2(direction * speed, playerRb.velocity.y);
        } else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }

        //Character to face correct direction
        if (direction > 0) //moving right
        {
            transform.localScale = new Vector3(6.037747f, transform.localScale.y, transform.localScale.z);
        } else if (direction < 0) //moving left
        {
            localScaleX = transform.localScale.x;
            transform.localScale = new Vector3(-6.037747f, transform.localScale.y, transform.localScale.z);
        }

        //Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, playerFeetRadius, groundLayer);
        playerAnimator.SetBool("Jumping", isGrounded);

        //Handle player jumping, player jumps when jump key is pressed and its not midair
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
    }
}
