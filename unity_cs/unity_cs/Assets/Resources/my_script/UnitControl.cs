using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitControl : MonoBehaviour {


    PhysicUnit physicUnit;

    bool bGoToDoor = false;
    //主角是否在門的位置

    // Use this for initialization
    void Start () {
        physicUnit = gameObject.GetComponent<PhysicUnit>();

        GameObject.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (bGoToDoor)
        {
            //把主角放到門的位置
            bGoToDoor = false;

            GameObject goDoor = GameObject.Find("door");
            if (goDoor != null)
            {
                gameObject.transform.position = goDoor.transform.position;
            }
        }
        

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            //檢查是否與門重疊
            GameObject goDoor = GameObject.Find("door");
            if(goDoor!=null)
            {
                BoxCollider2D doorBox = goDoor.GetComponent<BoxCollider2D>();
                BoxCollider2D heroBox = gameObject.GetComponent<BoxCollider2D>();


                if (BoxOverlap.check(doorBox, heroBox))
                {
                    PhysicUnit.vLine.Clear();
                    //清除舊廠景的地板線條

                    DoorInfo info = goDoor.GetComponent<DoorInfo>();
                    SceneManager.LoadScene(info.sceneName);
                    bGoToDoor = true;

                }
                
            }
        }

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
            Object obj = Resources.Load<Object>("my_prefab/rocket");

            GameObject newRocket = (GameObject)Instantiate<Object>(obj);
            newRocket.transform.position = new Vector3(gameObject.transform.position.x,
                                                       gameObject.transform.position.y+0.5f,
                                                       gameObject.transform.position.z);

            if (gameObject.transform.localScale.x > 0)
                newRocket.transform.localScale *= -1;
        }
    }
}
