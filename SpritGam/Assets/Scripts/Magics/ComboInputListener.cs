using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyName
{
    NONE,
    A,
    B,
    X,
    Y,
    RIGHT_BUMPER
}

public class ComboInputListener : MonoBehaviour
{
    private List<KeyName> m_current_combo = new List<KeyName>();
    private bool m_is_listening_for_combo = true;
    private float m_last_combo_input_time = 0.0f;
    private AbstractMagicCombo m_current_activated_spell = AllMagics.failed_spell_combo;

    [SerializeField] private float m_combo_time_interval = 1.0f;
    [SerializeField] private List<AbstractMagicCombo> m_avaliable_spells = new List<AbstractMagicCombo>();

    void Start()
    {
        StartCoroutine(listen_for_combo_input());
    }

    private IEnumerator listen_for_combo_input()
    {
        while (m_is_listening_for_combo)
        {
            KeyName key_press = get_key_down();

            if (m_last_combo_input_time + m_combo_time_interval < Time.time && m_current_combo.Count != 0)
            {
                end_combo();
            }

            if (key_press == KeyName.RIGHT_BUMPER && m_current_combo.Count != 0)
            {
                set_active_spell(m_current_combo);
                end_combo();
            }
            else if (key_press == KeyName.RIGHT_BUMPER && m_current_combo.Count == 0)
            {
                m_current_activated_spell.Activate(gameObject);
            }
            else if (key_press != KeyName.NONE)
            {
                m_current_combo.Add(key_press);
                m_last_combo_input_time = Time.time;
            }

            yield return null;
        }

        // code here to handle pause
    }

    private void end_combo()
    {
        m_current_combo = new List<KeyName>();
        m_last_combo_input_time = 0.0f;
    }

    private void set_active_spell(List<KeyName> combo)
    {
        AbstractMagicCombo combo_match = AllMagics.GetSpellForCombo(combo);
        m_current_activated_spell = combo_match;
        m_current_activated_spell.Activate(gameObject);
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

        if (ControllerInput.Pressed_RightBumper(Key.DOWN))
        {
            return KeyName.RIGHT_BUMPER;
        }

        return KeyName.NONE;
    }

    public List<KeyName> GetCurrentCombo()
    {
        return m_current_combo;
    }

    public AbstractMagicCombo GetCurrentSpell()
    {
        return m_current_activated_spell;
    }
}



