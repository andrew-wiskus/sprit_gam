using UnityEngine;
using System;
using UnityEngine.UI;

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
    [HideInInspector] public Image mod_UI_image;
    public Sprite gold_sprite;
    public Sprite silver_sprite;
    public Sprite bronze_sprite;
    public Sprite white_sprite;

    void Start()
    {
        wsc = GameObject.Find("config: weapon").GetComponent<WeaponStatConfig>();
        
        if (GetComponent<SpriteRenderer>() != null)
        {
            SetSprite();
            ModifyWeaponStats();
        } else
        {
            SetImage();
        }
        
        
    }

    private void SetSprite()
    {
        mod_image = GetComponent<SpriteRenderer>();
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
                sprite = null;
                break;
        }

        mod_image.sprite = sprite;
        //mod_UI_image.sprite = sprite;
    }

    private void SetImage()
    {
        //mod_UI_image.sprite = mod_image.sprite;
        mod_UI_image = GetComponent<Image>();

        switch (mod_rating)
        {
            case ModRating.GOLD:
                mod_UI_image.sprite = gold_sprite;
                break;

            case ModRating.SILVER:
                mod_UI_image.sprite = silver_sprite;
                break;

            case ModRating.BRONZE:
                mod_UI_image.sprite = bronze_sprite;
                break;

            case ModRating.WHITE:
                mod_UI_image.sprite = white_sprite;
                break;

            default:
                mod_UI_image.sprite = null;
                break;
        }
        
       // mod_UI_image.sprite = mod_UI_image.sprite;
    }

    public void ModifyWeaponStats()
    {

        foreach(ChipModStat stat in chipModStats)
        {
            if (stat.type == ModType.Damage)
            {
                wsc.damage += stat.increase_amount;
            }

            if (stat.type == ModType.Fire_Rate)
            {
                wsc.fire_rate +=  stat.increase_amount;
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