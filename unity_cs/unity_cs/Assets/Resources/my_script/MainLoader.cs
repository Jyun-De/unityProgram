using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoader : MonoBehaviour {
    //載入相機及主角

 
    static GameObject goMainCamera;
    static GameObject goHero;

    public Vector2 initPos;
    //主角出生位置

	// Use this for initialization
	void Start () {            

        if (goMainCamera != null)
            return;

        Object prefab = Resources.Load("my_prefab/Main Camera");
        goMainCamera = (GameObject)Instantiate(prefab);
        goMainCamera.name = "MainCamera";

        prefab = Resources.Load("my_prefab/hero");
        goHero = (GameObject)Instantiate(prefab);
        goHero.name = "hero";

        goHero.transform.position = new Vector3(initPos.x, 
                                                initPos.y,
                                                goHero.transform.position.z);

        CameraControl cc = goHero.GetComponent<CameraControl>();
        cc.goCamera = goMainCamera;

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
