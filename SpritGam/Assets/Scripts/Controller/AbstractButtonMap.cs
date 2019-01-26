using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractButtonMap : MonoBehaviour
{

    [SerializeField] private float m_left_trigger_deadzone;
    [SerializeField] private float m_right_trigger_deadzone = 0.2f;

    //public static bool OverrideToIndex = false;
    //public static int CurrentIndex = 0;

    //public abstract int ChannelID();

    public void SetOverrideActive(bool active)
    {
        //AbstractButtonMap.OverrideToIndex = active;
        if(active)
        {
            //AbstractButtonMap.CurrentIndex = ChannelID();
        }
    }


    void LateUpdate()
    {
        //if (AbstractButtonMap.OverrideToIndex && AbstractButtonMap.CurrentIndex != ChannelID())
        //{
        //    return;
        //}

        bool START_BUTTON = ControllerInput.Pressed_StartButton(Key.DOWN);
        bool LEFT_TRIGGER = ControllerInput.LeftTrigger() >= m_left_trigger_deadzone;
        bool RIGHT_TRIGGER = ControllerInput.RightTrigger() >= m_right_trigger_deadzone;
        bool RIGHT_TRIGGER_UP = ControllerInput.RightTrigger() <= m_right_trigger_deadzone;
        bool L3 = ControllerInput.Pressed_L3(Key.IS_PRESSED);

        bool X = ControllerInput.Pressed_X(Key.DOWN);
        bool Y = ControllerInput.Pressed_Y(Key.DOWN);
        bool B = ControllerInput.Pressed_B(Key.DOWN);
        bool A = ControllerInput.Pressed_A(Key.DOWN);

        bool DPAD_UP = ControllerInput.DpadVertical() > 0;
        bool DPAD_DOWN = ControllerInput.DpadVertical() < 0;
        bool DPAD_LEFT = ControllerInput.DpadHorizontal() > 0;
        bool DPAD_RIGHT = ControllerInput.DpadHorizontal() < 0;

        if (START_BUTTON) { OnPress_START(); }
        if (LEFT_TRIGGER) { OnPress_LEFT_TRIGGER(); }
        if (RIGHT_TRIGGER) { OnPress_RIGHT_TRIGGER(); }
        if (RIGHT_TRIGGER_UP) { OnPress_RIGHT_TRIGGER_UP(); }
        if (L3) { OnPress_L3(); }

        if (X) { OnPress_X(); }
        if (Y) { OnPress_Y(); }
        if (B) { OnPress_B(); }
        if (A) { OnPress_A(); }

        if (DPAD_UP) { OnPress_DPAD_UP(); }
        if (DPAD_DOWN) { OnPress_DPAD_DOWN(); }
        if (DPAD_LEFT) { OnPress_DPAD_LEFT(); }
        if (DPAD_RIGHT) { OnPress_DPAD_RIGHT(); }
    }

    public virtual void OnPress_START() { }
    public virtual void OnPress_LEFT_TRIGGER() { }
    public virtual void OnPress_RIGHT_TRIGGER() { }
    public virtual void OnPress_RIGHT_TRIGGER_UP() { }
    public virtual void OnPress_L3() { }

    public virtual void OnPress_X() { }
    public virtual void OnPress_Y() { }
    public virtual void OnPress_B() { }
    public virtual void OnPress_A() { }

    public virtual void OnPress_DPAD_UP() { }
    public virtual void OnPress_DPAD_DOWN() { }
    public virtual void OnPress_DPAD_LEFT() { }
    public virtual void OnPress_DPAD_RIGHT() { }
}

