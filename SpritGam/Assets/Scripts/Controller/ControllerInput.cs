using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// You can see the input mapping in the editor by going to
// Edit -> Project-Settings -> Input
public class ControllerInput : MonoBehaviour {

    public static float RightStickVertical()
    {
        return Input.GetAxis("Right_Vertical_Analog_Stick");
    }

    public static float RightStickHorizontal()
    {
        return Input.GetAxis("Right_Horizontal_Analog_Stick");
    }

    public static float LeftStickHorizontal()
    {
        return Input.GetAxis("Left_Horizontal_Analog_Stick");
    }

    public static float LeftStickVertical()
    {
        return Input.GetAxis("Left_Vertical_Analog_Stick");
    }

    public static float RightTrigger()
    {
        // this returns a float from 0 to -1. 
        //  0 == not pressed
        // -1 == fully pressed

        return Input.GetAxis("Right_Trigger");
    }
}
