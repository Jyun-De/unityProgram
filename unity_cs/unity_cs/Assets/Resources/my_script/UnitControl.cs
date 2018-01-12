using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitControl : MonoBehaviour {
    //BeBug 10 1404
    //看到 10 4500


    PhysicUnit physicUnit;

  
    string doorName = null;
    //到了新場景之後把主角放到指定名稱的門，null不須處理的門，可代替bGoToDoor 10 1324

    public static List<GameObject> vDoor = new List<GameObject>();

    // Use this for initialization
    void Start () {
        physicUnit = gameObject.GetComponent<PhysicUnit>();

        GameObject.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (doorName!=null)
        {
            //把主角放到門的位置
            GameObject goDoor = GameObject.Find(doorName);
            if (goDoor != null)
            {
                gameObject.transform.position = goDoor.transform.position;               
            }
            doorName = null;

        }
        

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            foreach (var goDoor in vDoor)
            {
                BoxCollider2D doorBox = goDoor.GetComponent<BoxCollider2D>();
                BoxCollider2D heroBox = gameObject.GetComponent<BoxCollider2D>();


                if (BoxOverlap.check(doorBox, heroBox))
                {
                    PhysicUnit.vLine.Clear();
                    //清除舊廠景的地板線條

                    doorName = goDoor.name;
                    DoorInfo info = goDoor.GetComponent<DoorInfo>();
                    SceneManager.LoadScene(info.sceneName);
              

                    vDoor.Clear();
                    //過場景時，將原場景的門清除
                    break;

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
