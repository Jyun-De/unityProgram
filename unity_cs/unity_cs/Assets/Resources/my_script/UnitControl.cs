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


        if(Input.GetKey(KeyCode.X))
        {
            //載入prefab
            Object obj = Resources.Load<Object>("my_sprite/rocket");

            GameObject newRocket = (GameObject)Instantiate<Object>(obj);
            newRocket.transform.position = new Vector3(gameObject.transform.position.x,
                                                       gameObject.transform.position.y+0.5f,
                                                       gameObject.transform.position.z);

            if (gameObject.transform.localScale.x > 0)
                newRocket.transform.localScale *= -1;
        }
    }
}
