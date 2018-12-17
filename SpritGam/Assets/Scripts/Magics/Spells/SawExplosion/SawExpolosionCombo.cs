using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawExplosionCombo : AbstractMagicCombo
{
    public bool isActive = false;

    public SawExplosionCombo() : base("Saw Explosion")
    {
        
        activation_sequence = new List<KeyName>() { KeyName.A, KeyName.A, KeyName.X };
    }

    public override void Activate(GameObject from_gameobject)
    {
        Debug.Log("EXPLOSISON");
        if (isActive)
        {
            return;
        }

        SawExplosion saw_explosion = from_gameobject.GetComponent<SawExplosion>();
        saw_explosion.StartSpellAnimation(this);
    }
}
