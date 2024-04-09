using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer1 : MonoBehaviour
{
    protected float horizontal;
    protected float runForce = 6f;
    protected float jumpForce = 300f;

    protected bool canJump = true;  //This bool dictates whether or not the player is enabled to jump.
    protected bool canMove = true;   //This bool dictates whether or not the player is enabled to run left and right.
    public bool Success;                   

    public GameObject GameOverText;   // This text appears when the player dies.
    public GameObject SuccessText;    // This text appears if both red and blue players reach the goal alive.

    [SerializeField] protected GameObject Other;  // Other player must be referenced so if red player dies, so does the blue player. 
    [SerializeField] protected Rigidbody2D rb;

    private int jumps = 2; // This is for the red player's double jump ability.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    protected virtual void Update()
    { 
        canJump = jumps > 0;
        if (Goal.Win) canMove = false;  // If the static bool win becomes true via both players reaching the goal, their running controls are disabled to prevent them from running off the cliff after the success text appears.
        if (!canMove) return; 
        horizontal = GetAxis();
        if (!canJump) return;
        if (Input.GetKeyDown(KeyCode.W)) // Clicking W makes the red player jump. Every W press decreases the jump counter by 1. If "jumps" = 0, the player can no longer jump until they are grounded.
        {
            rb.AddForce(Vector2.up * jumpForce); 
            jumps--;
        }
        
    }

    protected virtual float GetAxis() //Red Player 1 uses the A and D keys to run left and right
    {
        if (Input.GetKey(KeyCode.A))
        {
            return -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            return +1;
        }

        return 0;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * runForce, rb.velocity.y); // Player running velocity is determined here.
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard") //If Red Player 1 touches lava or a lava bubble, they die.
        {
            GameOverText.SetActive(true);
            Destroy(gameObject);
            Destroy(Other);
            // If red player dies, blue player is also destroyed.
        }

        if (collision.gameObject.tag == "Ground") // Red Player 1 is allowed to jump twice when touching the ground, meaning they can jump once off the ground, and again in midair as their midair special ability.
        {
            jumps = 2;
        }

        if (collision.gameObject.tag == "Finish") // With both players reaching the green goal cliff, the Success bool and Goal.Win bool become true. SuccessText is also set active.
        {
            Success = true; 
            if (Other.GetComponent<RedPlayer1>().Success)
            {
                SuccessText.SetActive(true);
                Goal.Win = true;
            }
        }
    }
}
