using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public float dashSpeed = 7;
    Coroutine dashing;
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        if (dashing != null)
        {
         StopCoroutine(dashing);
        }
       dashing = StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 7;
        while (speed > 3)
        {
            yield return null;
        }

        base.Attack();
        yield return new WaitForSeconds(0.1f);
            Instantiate(daggerPrefab, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(daggerPrefab, spawnPoint2.position, spawnPoint2.rotation);
        
    }

    private void Dash(Vector3 dst)
    {
        speed = 6;
        destination = dst;
    }

    
}
