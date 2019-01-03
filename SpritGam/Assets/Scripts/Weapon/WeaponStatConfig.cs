﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatConfig : MonoBehaviour {

    [SerializeField] ParticleSystem ps;

    public string weapon_name;
    //public string weapon_descriptor; TODO

    public float damage;
    public float bullet_speed;
    public float fire_rate;

    //public float accuracy_spread; TODO

    //public float reload_speed;
    public float bullet_richochet_count;
    //public float bullet_penetration_count;

    public float mana_cost_per_shot;
    //public float mana_capacity; // player stat

    public float crit_chance;
    public float crit_multiplier;

    //public string effect_type; TODO

    

	// Use this for initialization
	void Start () {
        SetWeaponStats();
	}

    public void SetWeaponStats()
    {
        var main = ps.main;
        var col = ps.collision;
        main.startSpeed = bullet_speed;

        // not working yet
        if (bullet_richochet_count > 0)
        {
            col.bounce = 1;
            col.lifetimeLoss = 1 / (1 + bullet_richochet_count);
        }

        // fire rate set on particle system script
        // TODO: create accuracy system
        // TODO: create reload delay system
        // TODO: create bullet penetration system
        // mana cost per shot handled by particle config
        // crit chance & crit rate handled by particle config
    }

    // Update is called once per frame
    void Update () {
		
	}
}
