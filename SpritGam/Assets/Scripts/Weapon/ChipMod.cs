using UnityEngine;
using System;

public enum ModRating
{
    WHITE,
    BRONZE,
    SILVER,
    GOLD
}

public enum ModType
{
    Damage,
    Fire_Rate,
    Accuracy,
    Crit_Chance,
    Crit_Multiplier
}

[Serializable]
public class ChipModStat
{
    public ModType type;
    public float increase_amount;
}

public class ChipMod : MonoBehaviour
{
    private WeaponStatConfig wsc;

    public ModRating mod_rating;
    public ChipModStat[] chipModStats;

    private SpriteRenderer mod_image;
    public Sprite gold_sprite;
    public Sprite silver_sprite;
    public Sprite bronze_sprite;
    public Sprite white_sprite;

    void Start()
    {
        wsc = GameObject.Find("config: weapon").GetComponent<WeaponStatConfig>();
        mod_image = GetComponent<SpriteRenderer>();
        SetSprite();
        ModifyWeaponStats();
    }

    private void SetSprite()
    {
        Sprite sprite = mod_image.sprite;

        switch(mod_rating)
        {
            case ModRating.GOLD:
                sprite = gold_sprite;
                break;

            case ModRating.SILVER:
                sprite = silver_sprite;
                break;

            case ModRating.BRONZE:
                sprite = bronze_sprite;
                break;

            case ModRating.WHITE:
                sprite = white_sprite;
                break;

            default:
                sprite = white_sprite;
                break;
        }

        mod_image.sprite = sprite;
    }

    private void ModifyWeaponStats()
    {

        foreach(ChipModStat stat in chipModStats)
        {
            if (stat.type == ModType.Damage)
            {
                wsc.damage += stat.increase_amount;
            }

            if (stat.type == ModType.Fire_Rate)
            {
                wsc.fire_rate -= (stat.increase_amount / 100);
            }

            if (stat.type == ModType.Accuracy)
            {
                wsc.accuracy += stat.increase_amount;
            }

            if (stat.type == ModType.Crit_Chance)
            {
                wsc.crit_chance += stat.increase_amount;
            }

            if (stat.type == ModType.Crit_Multiplier)
            {
                wsc.crit_multiplier += stat.increase_amount;
            }
            

        }
    }
}