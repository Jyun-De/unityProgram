using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControl : MonoBehaviour {


    PhysicUnit physicUnit;
    // Use this for initialization
    void Start () {
        physicUnit = gameObject.GetComponent<PhysicUnit>();

    }
	
	// Update is called once per frame
	void Update ()
    {

        //跳躍
        if (Input.GetKeyDown(KeyCode.Space))
        {
            physicUnit.jump();            
        }


        //左
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            physicUnit.moveLeft();
        }

        //右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            physicUnit.moveRight();
        }

    }
}
