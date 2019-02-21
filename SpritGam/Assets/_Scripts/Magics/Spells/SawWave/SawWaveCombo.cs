using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawWaveCombo : AbstractMagicCombo
{

    public bool isActive = false;

    public SawWaveCombo() : base("Saw Wave")
    {
        activation_sequence = new List<KeyName>() { KeyName.A, KeyName.A, KeyName.A };
    }

    public override void Activate(GameObject from_gameobject)
    {
        Debug.Log("MY NAME! " + Name);
        if(isActive)
        {
            return;
        }

        SawWave sawwave = from_gameobject.GetComponent<SawWave>();
        sawwave.StartSpellAnimation(this);
    }
}
