using UnityEngine;
using System.Collections.Generic;





public class Line
{
    public Vector2 form;
    public Vector2 to;
    public Line(Vector2 _from,Vector2 _to)
    {
        form = _from;
        to = _to;
    }

    public bool testIntersect(Line lineHorz, float wigth)
    {
        //檢查兩線是否重疊 https://imgur.com/0O1BtJe
        //條件的判定 https://imgur.com/QlEdHrI
        //增加寬度設定https://imgur.com/5RyhcdA
        if (form.x < lineHorz.form.x - wigth / 2)
            return false;
        if (form.x > lineHorz.to.x + wigth / 2)
            return false;
        if (form.y >= lineHorz.form.y &&
            to.y <= lineHorz.form.y)
            return true;
        else
            return false;

    }

}


public class hero : MonoBehaviour{

    //目前y軸速度
    float ySpeed=0;

    List<Line> vLine = new List<Line>();

    //主角的座標
    Vector2 pos;

    void makeLine(string goName)
    {

        //地板的線條
        GameObject goGround = GameObject.Find(goName);
        BoxCollider2D b2d = goGround.GetComponent<BoxCollider2D>();
        Vector2 leftPoint = new Vector2(b2d.bounds.min.x, b2d.bounds.max.y);
        Vector2 rightPoint = new Vector2(b2d.bounds.max.x, b2d.bounds.max.y);
        //bounds的資訊https://imgur.com/HEPPFdZ                    
        vLine.Add(new Line(leftPoint, rightPoint));
    }


	void Start()
	{
        makeLine ("myGround");
        makeLine("myPlatform");
       
    }

  

    void Update()
	{
       

        //目前的座標
        Vector2 oriPos = new Vector2(gameObject.transform.position.x, 
                                     gameObject.transform.position.y);
        
        //等速落下
        ySpeed -= 0.003f;
        
        gameObject.transform.Translate(0, ySpeed, 0);

        //位移過的座標
        Vector2 newPos = new Vector2(gameObject.transform.position.x,
                                     gameObject.transform.position.y);

        //主角的寬       
        BoxCollider2D b2d = gameObject.GetComponent<BoxCollider2D>();
        float heroW = b2d.bounds.max.x- b2d.bounds.min.x;
        Line lineHero = new Line(oriPos,newPos);
        

       

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
            ySpeed = 0.1f;
        }


        //左
        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            gameObject.transform.Translate(-0.03f, 0, 0);
        }

        //右
        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            gameObject.transform.Translate(0.03f, 0, 0);
        }

    }
}
