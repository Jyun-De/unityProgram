using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollideBox : MonoBehaviour {

	// Use this for initialization
	void Start () {        
        BoxCollider2D b2d = gameObject.GetComponent<BoxCollider2D>();
        MyRocket.vBox2D.Add(b2d);
    }
	

	void Update () {
		
	}
}
