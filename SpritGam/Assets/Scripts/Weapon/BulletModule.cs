using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum BonusEffect
{
    Damage,
    Ricochet,
    Size
}

public enum SpecialEffects
{
    Stun_Enemy,
    Burn_Enemy,
    Slag_Enemy
}

[Serializable]
public class SpecialEffect
{
    public SpecialEffects effect_type;
    public string effect_chance;
    public string effect_description;
}

[Serializable]
public class BonusStat
{
    public BonusEffect bonus_stats;
    public float stat_increase_amount;
}

[Serializable]
public class BulletObject
{
    public string bullet_name;
    public Sprite bullet_sprite;
    public Color bullet_color;
    public Gradient trail_gradient;
    
    public float mana_cost_per_shot;
    public float bullet_speed;

    public SpecialEffect special_effect;
    public BonusStat[] bullet_bonus_stats;
}

public class BulletModule : MonoBehaviour {

    private ParticleWeaponConfig pwc;
    private BulletGenerator bg;
    public BulletObject bullet;
    private WeaponStatConfig wsc;

    void Start()
    {
        pwc = GameObject.Find("config: particle_weapon").GetComponent<ParticleWeaponConfig>();
        bg = GameObject.Find("BulletGenerator").GetComponent<BulletGenerator>();
        wsc = GetComponent<WeaponStatConfig>();
        ModifyWeaponStats();
    }

    private void ModifyWeaponStats()
    {
        foreach (BonusStat bonusStat in bullet.bullet_bonus_stats)
        {
            if (bonusStat.bonus_stats == BonusEffect.Damage)
            {
                wsc.damage += bonusStat.stat_increase_amount;
            }
        }
    }

    void FixedUpdate()
    {
        bullet.bullet_name = bg.generated_bullet_name;
    }

}
