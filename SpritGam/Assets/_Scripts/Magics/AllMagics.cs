using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMagics
{

    public static SawBeamCombo saw_beam_combo = new SawBeamCombo();
    public static SawWaveCombo saw_wave_combo = new SawWaveCombo();
    public static SawExplosionCombo saw_explosion_combo = new SawExplosionCombo();

    public static FailedSpellCombo failed_spell_combo = new FailedSpellCombo();

    public static List<AbstractMagicCombo> all_spells = new List<AbstractMagicCombo>()
    {
        saw_beam_combo,
        saw_wave_combo,
        saw_explosion_combo,
    };

    public static AbstractMagicCombo GetSpellForCombo(List<KeyName> combo)
    {
        for (int i = 0; i < AllMagics.all_spells.Count; i++)
        {
            if (AllMagics.all_spells[i].CheckForMatchedSequence(combo))
            {
                return AllMagics.all_spells[i];
            }
        }

        return AllMagics.failed_spell_combo;
    }
}



