using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMagicCombo
{
    public List<KeyName> activation_sequence = new List<KeyName>();
    public string Name;

    public AbstractMagicCombo(string name)
    {
        Name = name;
    }

    public bool CheckForMatchedSequence(List<KeyName> sequence)
    {
        if (sequence.Count != activation_sequence.Count)
        {
            return false;
        }

        for (int i = 0; i < activation_sequence.Count; i++)
        {
            if (activation_sequence[i] != sequence[i])
            {
                return false;
            }
        }

        return sequence.Count != 0;
    }

    public abstract void Activate(GameObject from_gameobject);
}
