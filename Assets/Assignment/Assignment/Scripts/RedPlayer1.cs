using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer1 : MonoBehaviour
{
    protected float horizontal;
    protected float runForce = 5f;
    protected float jumpForce = 300f;

    [SerializeField] protected Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = GetAxis();
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce);
            print("jump");
        }
    }

    protected virtual float GetAxis()
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
        rb.velocity = new Vector2(horizontal * runForce, rb.velocity.y);
    }
}
