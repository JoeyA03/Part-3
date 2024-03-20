using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Transform Square1;
    public Transform Square2;
    public Transform Square3;

    public Vector2 maxSquare1Size;
    public Vector2 maxSquare2Size;
    public Vector2 maxSquare3Size;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BuildingScale());
    }

    private IEnumerator BuildingScale()
    {
        float time1 = 1f;
        float timer = 0;
        while (timer < time1) 
        {
            Square1.localScale = Vector2.Lerp(Vector2.right, maxSquare1Size, timer / time1);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        timer = 0;
        float time2 = 1f; 
        while (timer < time2) 
        { 
        Square2.localScale = Vector2.Lerp(Vector2.right, maxSquare2Size, timer / time2);
            timer += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        timer = 0;
        float time3 = 1f;
        while (timer < time3)
        {
            Square3.localScale = Vector2.Lerp(Vector2.right, maxSquare3Size, timer / time3);
            timer += Time.deltaTime;
            yield return null;
        }


    }
}
