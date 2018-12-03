using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicGUI : MonoBehaviour {

    [SerializeField] private Text m_text;
    [SerializeField] private ComboInputListener m_combo_listener;

    void Update () {
        m_text.text = current_spell_text() + "\n\n" + current_combo_text() + "\n\n" + spell_list();
	}

    private string current_spell_text()
    {
        return "Current Spell: " + m_combo_listener.GetCurrentSpell().Name;
    }

    private string current_combo_text()
    {
        string combo_str = "";
        List<KeyName> current_combo = m_combo_listener.GetCurrentCombo();
        foreach (var button in current_combo)
        {
            combo_str += button.ToString() + " > ";
        }

        return "Current Combo: " + combo_str;

    }

    private string spell_list()
    {
        string return_str = "";

        foreach (var item in AllMagics.all_spells)
        {
            string combo_str = "";

            foreach (var button in item.activation_sequence)
            {
                combo_str += button.ToString() + "  ";
            }

            return_str += "\n" + combo_str + ":  " + item.Name;
        }

        return return_str;
    }
}
