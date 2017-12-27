using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOverlap  {

    static public bool check(BoxCollider2D boxA, BoxCollider2D boxB)
    {
        
        if (boxA.bounds.min.x > boxB.bounds.max.x)
            return false;
        //沒有重疊
        if (boxA.bounds.max.x < boxB.bounds.min.x)
            return false;
        if (boxA.bounds.min.y > boxB.bounds.max.y)
            return false;
        if (boxA.bounds.max.y < boxB.bounds.min.y)
            return false;

        return true;

    }
}
