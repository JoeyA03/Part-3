using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBubble3 : LavaBubble2
{
    // Lava Bubble 3 inherits from Lava Bubble 2.

    // Start is called before the first frame update
    void Start()
    {
        // The third lava bubble only waits one second before jumping out of the lava (again).
        StartCoroutine(LavaJump(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override IEnumerator LavaJump(float delay)
    {
        while (true)
        {
            // Float delay is shorter. (See void Start())
            yield return new WaitForSeconds(delay);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
        }

    }
}
