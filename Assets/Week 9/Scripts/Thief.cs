using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    protected override void Attack()
    {
        destination = transform.position;
        base.Attack();
        Instantiate(daggerPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(daggerPrefab, spawnPoint2.position, spawnPoint2.rotation);
        Dash(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void Dash(Vector3 dst)
    {
        speed = 6;
        destination = dst;
    }
}
