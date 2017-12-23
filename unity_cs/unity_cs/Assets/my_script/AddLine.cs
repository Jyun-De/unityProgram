using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLine : MonoBehaviour {

	void Start () {
        //把線條記錄到hero的 vLine
        //地板的線條
        GameObject goHero = GameObject.Find("hero");
        
        Hero hero = goHero.GetComponent<Hero>();

        
        BoxCollider2D b2d = gameObject.GetComponent<BoxCollider2D>();
        Vector2 leftPoint = new Vector2(b2d.bounds.min.x, b2d.bounds.max.y);
        Vector2 rightPoint = new Vector2(b2d.bounds.max.x, b2d.bounds.max.y);
        //bounds的資訊https://imgur.com/HEPPFdZ                    
        Hero.vLine.Add(new Line(leftPoint, rightPoint));
    }
	
}
