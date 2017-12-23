using UnityEngine;
using System.Collections.Generic;
//3000介紹 const static get set的語法

public class Hero : MonoBehaviour{

    //1秒鐘橫移的速度 https://imgur.com/VyDNEj8
    const float X_SPEED = 2;
    
    //每秒的加速度
    const float Y_ACCE = -7f;


    //目前y軸速度
    float ySpeed=0;

    static public List<Line> vLine = new List<Line>();

    //主角的座標
    Vector2 pos;

    void makeLine(string goName)
    {

    }


	void Start()
	{
       
       
    }

  

    void Update()
	{
       

        //目前的座標
        Vector2 oriPos = new Vector2(gameObject.transform.position.x, 
                                     gameObject.transform.position.y);
        
        //等速落下
        ySpeed += Y_ACCE * Time.deltaTime;
        
        gameObject.transform.Translate(0, ySpeed*Time.deltaTime, 0);

        //位移過的座標
        Vector2 newPos = new Vector2(gameObject.transform.position.x,
                                     gameObject.transform.position.y);

        Line lineHero = new Line(oriPos, newPos);
        //主角的寬       
        BoxCollider2D b2d = gameObject.GetComponent<BoxCollider2D>();
        float heroW = b2d.bounds.max.x- b2d.bounds.min.x;
      
        

       

        //抓出vLine中所有的線條 https://imgur.com/dcP2v2V
        foreach (Line cur in vLine)
        {
            if (lineHero.testIntersect(cur, heroW))
            {
                //著地
                    gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                                cur.form.y,
                                                                gameObject.transform.position.z);
                ySpeed = 0;
            }
        }
       
       


        //跳躍
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ySpeed = 6.5f;
        }


        //左
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            gameObject.transform.Translate(-X_SPEED * Time.deltaTime, 0, 0);
        }

        //右
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            gameObject.transform.Translate(X_SPEED * Time.deltaTime, 0, 0);
        }

    }
}
