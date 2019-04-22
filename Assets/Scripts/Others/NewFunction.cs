using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFunction : Singleton<NewFunction>
{


    public IEnumerator MoveToPoint(Transform original, Vector2 target, float speed,bool isDead=false)
    {
        while (original.position.y != target.y && !isDead)
        {
            original.position = Vector2.MoveTowards(original.position, target, speed * Time.deltaTime);
           
            yield return null;
            

        }


    }
}
