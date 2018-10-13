using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Key
{
    DOWN,
    UP,
    IS_PRESSED
}

// You can see the input mapping in the editor by going to
// Edit -> Project-Settings -> Input
public class ControllerInput : MonoBehaviour
{

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
        return Input.GetAxis("Right_Trigger") * -1.0f; //reversing because it returns 0 to -1;
    }

    public static float LeftTrigger()
    {
        return -Input.GetAxis("Left_Trigger");
    }

    private static bool ButtonPress(string for_button, Key key)
    {
        string joystick_button = "joystick button " + for_button;

        if (key == Key.DOWN)
        {
            return Input.GetKeyDown(joystick_button);
        }

        if (key == Key.UP)
        {
            return Input.GetKeyUp(joystick_button);
        }

        return Input.GetKey(joystick_button);
    }

    public static bool Pressed_A(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("0", key);
    }

    public static bool Pressed_B(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("1", key);
    }

    public static bool Pressed_X(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("2", key);
    }

    public static bool Pressed_Y(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("3", key);
    }

    public static bool Pressed_LeftBumper(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("4", key);
    }

    public static bool Pressed_RightBumper(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("5", key);
    }

    public static bool Pressed_BackButton(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("6", key);
    }

    public static bool Pressed_StartButton(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("7", key);
    }

    public static bool Pressed_L3(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("8", key);
    }

    public static bool Pressed_R3(Key key = Key.IS_PRESSED)
    {
        return ControllerInput.ButtonPress("9", key);
    }
}
