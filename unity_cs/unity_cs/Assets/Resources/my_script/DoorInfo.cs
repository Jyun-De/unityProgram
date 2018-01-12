using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInfo : MonoBehaviour {

    public string sceneName = "";

	// Use this for initialization
	void Start () {
        UnitControl.vDoor.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
