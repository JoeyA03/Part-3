using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBubble2 : LavaBubble1
{
   // Lava Bubble 2 inherits from Lava Bubble 1.

    // Start is called before the first frame update
    void Start()
    {
        // Lava Bubble 2 waits 1.5 seconds before jumping out of the lava when the game starts.
        StartCoroutine(LavaJump(1.5f)); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override IEnumerator LavaJump(float delay)
    {
        while (true)
        {
            // Same as Lava Bubble 1, but the float delay is shorter. (See void Start())
            yield return new WaitForSeconds(delay);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
        }

    }
}
