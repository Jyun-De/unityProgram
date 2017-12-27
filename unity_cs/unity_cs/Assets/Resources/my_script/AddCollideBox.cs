using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollideBox : MonoBehaviour {

	// Use this for initialization
	void Start () {


        BoxCollider2D b2d = gameObject.GetComponent<BoxCollider2D>();
        MyRocket.vBox2D.Add(b2d);


        //Vector2 leftPoint = new Vector2(b2d.bounds.min.x, b2d.bounds.max.y);
        //Vector2 rightPoint = new Vector2(b2d.bounds.max.x, b2d.bounds.max.y);
        ////bounds的資訊https://imgur.com/HEPPFdZ                    
        //PhysicUnit.vLine.Add(new Line(leftPoint, rightPoint));
    }
	

	void Update () {
		
	}
}
