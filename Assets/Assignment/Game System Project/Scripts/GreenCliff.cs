using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCliff : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject LavaBubble1;
    public GameObject LavaBubble2;
    public GameObject LavaBubble3;
    public GameObject Lava; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player1")
        {
            Destroy(GameObject.FindGameObjectWithTag("Hazard"));
        }

        if (collision.gameObject.name == "Player2")
        {
            Destroy(GameObject.FindGameObjectWithTag("Hazard"));
        }
    }
}
