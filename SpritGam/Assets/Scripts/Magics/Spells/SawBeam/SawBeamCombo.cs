using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBeamCombo : AbstractMagicCombo
{
    public bool isActive = false;

    public SawBeamCombo() : base("Saw Beam")
    {
        activation_sequence = new List<KeyName>() { KeyName.A, KeyName.A };
    }

    public override void Activate(GameObject from_gameobject)
    {
        if (isActive)
        {
            return;
        }

        SawBeam saw_beam = from_gameobject.GetComponent<SawBeam>();
        saw_beam.StartSpellAnimation(this);
    }
}