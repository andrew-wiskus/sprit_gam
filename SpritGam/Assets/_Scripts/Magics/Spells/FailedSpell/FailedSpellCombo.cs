using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedSpellCombo : AbstractMagicCombo
{
    public FailedSpellCombo() : base ("None")
    {
        activation_sequence = new List<KeyName>();
    }

    public override void Activate(GameObject from_gameobject)
    {
        // play poof on character; fail noise; etc;
        Debug.Log("POOOOF");
    }
}