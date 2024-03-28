using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer2 : RedPlayer1
{
   

    void Update()
    {
        if (Goal.Win) canMove = false;
        if (!canMove) return;
        horizontal = GetAxis();
        if (!canJump) return;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce);
            canJump = false;
        }
    }

    protected override float GetAxis()
    {
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
}
