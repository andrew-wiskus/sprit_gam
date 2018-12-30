using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractButtonMap : MonoBehaviour
{

    [SerializeField] private float m_left_trigger_deadzone;
    [SerializeField] private float m_right_trigger_deadzone = 0.2f;

    void LateUpdate()
    {
        bool START_BUTTON = ControllerInput.Pressed_StartButton(Key.DOWN);
        bool LEFT_TRIGGER = ControllerInput.LeftTrigger() >= m_left_trigger_deadzone;
        bool RIGHT_TRIGGER = ControllerInput.RightTrigger() >= m_right_trigger_deadzone;
        bool RIGHT_TRIGGER_UP = ControllerInput.RightTrigger() <= m_right_trigger_deadzone;
        bool L3 = ControllerInput.Pressed_L3(Key.IS_PRESSED);

        bool X = ControllerInput.Pressed_X(Key.DOWN);
        bool Y = ControllerInput.Pressed_Y(Key.DOWN);
        bool B = ControllerInput.Pressed_B(Key.DOWN);
        bool A = ControllerInput.Pressed_A(Key.DOWN);

        if (START_BUTTON) { OnPress_START(); }
        if (LEFT_TRIGGER) { OnPress_LEFT_TRIGGER(); }
        if (RIGHT_TRIGGER) { OnPress_RIGHT_TRIGGER(); }
        if (RIGHT_TRIGGER_UP) { OnPress_RIGHT_TRIGGER_UP(); }
        if (L3) { OnPress_L3(); }

        if (X) { OnPress_X(); }
        if (Y) { OnPress_Y(); }
        if (B) { OnPress_B(); }
        if (A) { OnPress_A(); }
    }

    public virtual void OnPress_START() { }
    public virtual void OnPress_LEFT_TRIGGER() {}
    public virtual void OnPress_RIGHT_TRIGGER() {}
    public virtual void OnPress_RIGHT_TRIGGER_UP() { }
    public virtual void OnPress_L3() {} 

    public virtual void OnPress_X() {} 
    public virtual void OnPress_Y() {} 
    public virtual void OnPress_B() {} 
    public virtual void OnPress_A() {} 

}

