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



