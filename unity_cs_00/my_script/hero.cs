using UnityEngine;
using System.Collections;

public class hero : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//修改gameobject的座標
		//不斷的x加上0.01
		gameObject.transform.Translate(0.01f, 0, 0);
	}
}
