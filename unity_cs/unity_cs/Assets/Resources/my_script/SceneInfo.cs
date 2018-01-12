using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInfo : MonoBehaviour {

    public int sceneW, sceneH;
    //場景有幾個銀幕大
    //https://imgur.com/DnN8PIe

    static public float sceneSizeW, sceneSizeH;
    //場景的大小

    // Use this for initialization
    void Start () {

        //https://imgur.com/v5Ui6nn ，orthographicSize = 5、aspect是一個比例，根據自己的設定值16;10之類的等等
        float viewW = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        float viewH = Camera.main.orthographicSize * 2;//5*2

        //一個場景有幾個鏡頭大小
        float sceneW = viewW * sceneSizeW;
        float sceneH = viewH * sceneSizeH;


    }

    // Update is called once per frame
    void Update () {
        if(sceneSizeW==0)
        {
            if(Camera.main!=null)
            {
                //在camera產生後算出這些值，sceneSizeW!=下次就不會重新執行此段程式碼
                float viewW = Camera.main.orthographicSize * 2 * Camera.main.aspect;
                float viewH = Camera.main.orthographicSize * 2;           
                float sceneW = viewW * sceneSizeW;
                float sceneH = viewH * sceneSizeH;
            }
        }

		
	}
}
