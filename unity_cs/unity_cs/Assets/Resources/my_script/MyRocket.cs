using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRocket : MonoBehaviour {

    //火箭生命長度
    float lifeTime = 3;

    public static List<BoxCollider2D> vBox2D = new List<BoxCollider2D>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        const float X_SPEED = 10;

        if(gameObject.transform.localScale.x>0)
           gameObject.transform.Translate(X_SPEED * Time.deltaTime, 0, 0);
        else
           gameObject.transform.Translate(-X_SPEED * Time.deltaTime, 0, 0);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);

        //火箭自己的B2D
        BoxCollider2D b2d = GetComponent<BoxCollider2D>();
        foreach (var cur in vBox2D)
        {

            //cur物件本身的方塊,vBox裝載在怪物上或...的方塊
            //是否重疊 https://imgur.com/DiFPzM7
            bool bOverlap = true;
            if (cur.bounds.min.x > b2d.bounds.max.x)
                bOverlap = false;
            if (cur.bounds.max.x < b2d.bounds.min.x)
                bOverlap = false;
            if (cur.bounds.min.y > b2d.bounds.max.y)
                bOverlap = false;
            if (cur.bounds.max.y < b2d.bounds.min.y)
                bOverlap = false;

            //有重疊
            if (bOverlap)
            {
                vBox2D.Remove(cur);

                Destroy(gameObject);
                Destroy(cur.gameObject);

                break;
            }
                
        }
    }

  
}
