using UnityEngine;
using System.Collections.Generic;
//3000介紹 const static get set的語法
//07 5300 DeBug https://imgur.com/giwzNVs 先後順序配置
//07 010700 DeBug 平台踩不上去
public class PhysicUnit : MonoBehaviour {

    //1秒鐘橫移的速度 https://imgur.com/VyDNEj8
    public float X_SPEED = 2;

    //每秒的加速度
    const float Y_ACCE = -7f;


    //目前y軸速度
    float ySpeed = 0;

    static public List<Line> vLine = new List<Line>();

    //是否站在地板上
    bool bGround=false;

    BoxCollider2D bodyBox;

    public void jump()
    {
        //if(bGround==true)
        ySpeed = 10.5f;
    }
    public void moveRight()
    {
        gameObject.transform.Translate(X_SPEED * Time.deltaTime, 0, 0);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
             
    }

    public void moveLeft()
    {
        gameObject.transform.Translate(-X_SPEED * Time.deltaTime, 0, 0);
        gameObject.transform.localScale = new Vector3(-1, 1, 1);
        
    }





    void Start()
	{
        bodyBox = GetComponent<BoxCollider2D>();
       
    }

    void fixPossition()
    {
        


        //修正主角位置，使主角不會超出關卡邊界
        if (bodyBox.bounds.min.x < 0)
        {
            //左邊出界
            gameObject.transform.position = new Vector3(bodyBox.size.x / 2+0.5f,
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z);
        }
        if (bodyBox.bounds.max.x <= SceneInfo.sceneSizeW)
        {
            //右邊出界
            gameObject.transform.position = new Vector3(SceneInfo.sceneSizeW-(bodyBox.size.x),
                                                        gameObject.transform.position.y,
                                                        gameObject.transform.position.z);
        }
        if (bodyBox.bounds.max.y > SceneInfo.sceneSizeH)
        {
            //上邊出界
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        SceneInfo.sceneSizeH-(bodyBox.size.y),
                                                        gameObject.transform.position.z);
        }
        if (bodyBox.bounds.min.y < 0)
        {
            //下邊出界
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        1,
                                                        gameObject.transform.position.z);
        }

    }

    void Update()
	{
       

        //目前的座標
        Vector2 oriPos = new Vector2(gameObject.transform.position.x, 
                                     gameObject.transform.position.y);
        
        //等速落下
        ySpeed += Y_ACCE * Time.deltaTime;
        
        gameObject.transform.Translate(0, ySpeed*Time.deltaTime, 0);

        oriPos.y += 0.01f;
        //位移過的座標
        Vector2 newPos = new Vector2(gameObject.transform.position.x,
                                     gameObject.transform.position.y);

        Line lineHero = new Line(oriPos, newPos);
        //主角的寬       
        BoxCollider2D b2d = gameObject.GetComponent<BoxCollider2D>();
        float heroW = b2d.bounds.max.x- b2d.bounds.min.x;




        bGround = false;
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
                bGround = true;
            }
        }

        fixPossition();



    }
}
