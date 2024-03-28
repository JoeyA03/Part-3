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
        StartCoroutine(LavaJump(2));
    }

    protected virtual IEnumerator LavaJump(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
