using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rank
{
    WHITE,
    BRONZE,
    SILVER,
    GOLD
}

public enum Variable
{
    DAMAGE,
    FIRE_RATE,
    ACCURACY,
    CRIT_CHANCE,
    CRIT_MULTIPLIER
}

public class ChipModOld : MonoBehaviour {

    private WeaponStatConfig wsc;

    public Rank rank;

    public Variable[] variables;
    
    private int number_of_attributes;

    private float[] stat_modifiers;

    //public ChipModStat[] chip_mods;



    // Use this for initialization
    void Start () {
        wsc = GetComponentInParent<WeaponStatConfig>();

        stat_modifiers = new float[]
        {
            wsc.damage,
            wsc.fire_rate,
            wsc.accuracy,
            wsc.crit_chance,
            wsc.crit_multiplier
        };
        
        SetNumberOfSlots();
	}

    void SetNumberOfSlots()
    {
        switch (rank)
        {
            case Rank.GOLD:
                number_of_attributes = 3;
                break;

            case Rank.SILVER:
                number_of_attributes = 2;
                break;

            case Rank.BRONZE:
                number_of_attributes = 1;
                break;

            case Rank.WHITE:
                number_of_attributes = 0;
                break;

            default:
                number_of_attributes = 0;
            break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
