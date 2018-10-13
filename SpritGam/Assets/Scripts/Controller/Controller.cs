using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    public static float GetRightAnalogStickAngle()
    {

        float y = ControllerInput.RightStickVertical();
        float x = ControllerInput.RightStickHorizontal();
        float angle = Mathf.Atan2(y, x) - Mathf.PI / 2;
        angle = Mathf.Rad2Deg * angle;

        if (angle < 0)
        {
            angle = angle * -1.0f;
        }
        else if (angle > 0)
        {
            angle = (90.0f - angle) + 270.0f;
        }

        return angle;
    }
}