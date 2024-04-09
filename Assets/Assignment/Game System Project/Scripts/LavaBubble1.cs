using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBubble1 : MonoBehaviour
{

    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float jumpForce = 500f;

    // Start is called before the first frame update
    void Start()
    {
        // Lava Bubble 1 waits 2 seconds before jumping out of the lava when the game starts.
        StartCoroutine(LavaJump(2));
    }

    protected virtual IEnumerator LavaJump(float delay)
    {
        while (true)
        {
            // Here, Lava Bubble 1 is also instructed to wait the delay time before jumping out of the lava again. They can only jump in a straight upward direction and with an exact jump force.
            yield return new WaitForSeconds(delay);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
