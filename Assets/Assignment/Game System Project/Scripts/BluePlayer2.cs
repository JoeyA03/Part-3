using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer2 : RedPlayer1

   // Player 2 inherits from Player 1.
{
    private bool canDash; // This bool dictates whether or not Player 2 can use their dash ability

    protected override void Update()
    {
        if (Goal.Win) canMove = false; // If the static bool win becomes true via both players reaching the goal, their running controls are disabled to prevent them from running off the cliff after the success text appears.
        if (!canMove) return;
        horizontal = GetAxis();
        if (Input.GetKeyDown(KeyCode.UpArrow)) // Click the up arrow key to make Player 2 jump. If Player 2's jump key is clicked in midair, Player 2 will use their dash ability.
        {
            if (canJump)
            {
                Jump();
            }
            else 
            {
                if (canDash) 
                {
                    Dash();
                }
            }
        }
    }
    private void Jump()
    {   // Press the up arrow key to make the blue player jump.
        rb.AddForce(Vector2.up * jumpForce);
        canJump = false;
    }
    private void Dash()
    {
        //If the blue player's jump key is clicked in midair, they use their dash ability. They slide-boost by a certain distance to the right before falling back to the ground.
        rb.AddForce(Vector2.right * jumpForce*15);
        canDash = false;
    }
    protected override float GetAxis()
    { 
        //The blue player uses the left and right arrow keys to run left and right.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            return +1;
        }
        return 0;
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        // If the blue player is touching the ground, they are enabled to jump and use their dash ability in midair.
        base.OnCollisionEnter2D(collision);
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            canDash = true;
        }
    }
}
