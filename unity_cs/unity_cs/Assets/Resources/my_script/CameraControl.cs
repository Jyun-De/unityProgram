using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    //先出現主角攝影機在移動 https://imgur.com/Fl273Ee
    

    GameObject goCamera;
    
    
	// Use this for initialization
	void Start () {
        goCamera = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        goCamera.transform.position = new Vector3(gameObject.transform.position.x,
                                                  gameObject.transform.position.y + 3,
                                                  gameObject.transform.position.z - 1);
	}
}
