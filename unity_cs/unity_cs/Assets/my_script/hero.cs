using UnityEngine;



public class hero : MonoBehaviour{

    //目前y軸速度
    float ySpeed;

	void Start()
	{
	}

	
	void Update()
	{

        //等速落下
        ySpeed -= 0.003f;
        gameObject.transform.Translate(0, ySpeed, 0);

        if(gameObject.transform.position.y<0)
        {
            //著地
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 
                                                        0, 
                                                        gameObject.transform.position.z);
            ySpeed = 0;
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
