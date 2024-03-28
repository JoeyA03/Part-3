using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBubble3 : LavaBubble2
{

    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(delay);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
        }

    }
}
