using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayer2 : RedPlayer1
{

    void Update()
    {
        horizontal = GetAxis();
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up * jumpForce);
            print("jump");
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
