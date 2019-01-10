using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatConfig : AbstractButtonMap {

    private ParticleSystem ps;

    private WeaponNameGenerator wng;

    public string weapon_name;
    //public string weapon_descriptor; TODO
    public float damage;
    public float bullet_speed;
    public float fire_rate;
    //public float accuracy_spread; // TODO
    //public float reload_speed; // TODO
    public float bullet_richochet_count;
    //public float bullet_penetration_count; // TODO
    public float mana_cost_per_shot;
    public float crit_chance;
    public float crit_multiplier;
    //public string effect_type; TODO

    public string fire_type;
    public float accuracy;

    
	void Start () {
        ps = GameObject.Find("Player").GetComponentInChildren<ParticleSystem>();
        wng = GameObject.Find("WeaponNameGenerator").GetComponent<WeaponNameGenerator>();
        SetWeaponStats();
	}

    public void SetWeaponStats()
    {
        var main = ps.main;
        var col = ps.collision;
        main.startSpeed = bullet_speed;
        fire_rate = fire_rate / 100;

        weapon_name = wng.generated_weapon_name;

        // not working yet
        if (bullet_richochet_count > 0)
        {
            col.bounce = 1;
            col.lifetimeLoss = 1 / (bullet_richochet_count + 1);
        }
        
        // TODO: create accuracy system
        // TODO: create reload delay system
        // TODO: create bullet penetration system
    }

    public override void OnPress_Y()
    {
        wng.GenerateNewWeaponName();
        weapon_name = wng.generated_weapon_name;
    }




    void FixedUpdate () {
		
	}
}
