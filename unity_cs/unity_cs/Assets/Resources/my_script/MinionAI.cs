using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour {


    GameObject goHero;
    PhysicUnit physicUnit;
    // Use this for initialization
    void Start () {
        
        physicUnit = gameObject.GetComponent<PhysicUnit>();
        

    }
	
	// Update is called once per frame
	void Update () {
        if (goHero == null)
        {
            goHero = GameObject.Find("hero");
            if (goHero == null)
                return;
        }
            

        if (goHero.transform.position.x > gameObject.transform.position.x)
            physicUnit.moveRight();

        if (goHero.transform.position.x < gameObject.transform.position.x)                  
            physicUnit.moveLeft();


    }
}
