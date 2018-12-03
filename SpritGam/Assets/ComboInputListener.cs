using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum KeyName
{
    NONE,
    A,
    B,
    X,
    Y,
}

public class ComboInputListener : MonoBehaviour
{
    private List<KeyName> m_current_combo = new List<KeyName>();
    private bool m_is_listening_for_combo = true;
    [SerializeField] private float m_combo_time_interval = 1.0f;

    void Start()
    {
        StartCoroutine(listen_for_combo_input());
    }

    private IEnumerator listen_for_combo_input()
    {
        float last_combo_input_time = 0.0f;

        while (m_is_listening_for_combo)
        {
            KeyName key_press = get_key_down();

            if (last_combo_input_time + m_combo_time_interval < Time.time && m_current_combo.Count != 0)
            {
                Debug.Log("COMBO ENDED");
                m_current_combo = new List<KeyName>();
                last_combo_input_time = 0.0f;
            }

            if (key_press != KeyName.NONE)
            {
                m_current_combo.Add(key_press);
                last_combo_input_time = Time.time;

                Debug.Log("CURRENT COMBO: " + Util.PrintList<KeyName>(m_current_combo));
            }

            yield return null;
        }

        // code here to handle pause
    }

    private KeyName get_key_down()
    {
        if (ControllerInput.Pressed_A(Key.DOWN))
        {
            return KeyName.A;
        }

        if (ControllerInput.Pressed_B(Key.DOWN))
        {
            return KeyName.B;
        }

        if (ControllerInput.Pressed_X(Key.DOWN))
        {
            return KeyName.X;
        }

        if (ControllerInput.Pressed_Y(Key.DOWN))
        {
            return KeyName.Y;
        }

        return KeyName.NONE;
    }
}