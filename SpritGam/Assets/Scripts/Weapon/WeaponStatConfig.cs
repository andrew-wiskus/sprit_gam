using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatConfig : AbstractButtonMap {

    private ParticleSystem ps;

    private WeaponNameGenerator wng;

    public string weapon_name;
    //public string weapon_descriptor; TODO

    public float base_damage;
    public float base_fire_rate;
    public float base_accuracy;
    public float base_crit_chance;
    public float base_crit_multi;

    [HideInInspector] public float damage;
    [HideInInspector] public float bullet_speed;
    [HideInInspector] public float fire_rate;
    [HideInInspector] public string fire_type;
    [HideInInspector] public float accuracy;
    [HideInInspector] public float crit_chance;
    [HideInInspector] public float crit_multiplier;

    [HideInInspector] public float bullets_per_second;


    //public float accuracy_spread; // TODO
    //public float reload_speed; // TODO
    public float bullet_richochet_count;
    //public float bullet_penetration_count; // TODO
    //public float mana_cost_per_shot;
    //public string effect_type; TODO

    

    public GameObject[] chip_mods;
    private int stat_count = 0;

    
	void Start () {
        SetInitialAmounts();
        ps = GameObject.Find("Player").GetComponentInChildren<ParticleSystem>();
        wng = GameObject.Find("WeaponNameGenerator").GetComponent<WeaponNameGenerator>();
        
        SetWeaponStats();
	}

    public void LogWeaponStats()
    {
        stat_count++;
        Debug.Log("NEW SET ----------------------------" + stat_count);
        Debug.Log("damage: " + damage);
        Debug.Log("fire rate: " + fire_rate);
        Debug.Log("accuracy: " + accuracy);
        Debug.Log("crit chance: " + crit_chance);
        Debug.Log("crit multiplier: " + crit_multiplier);
    }

    void SetInitialAmounts()
    {
        damage = base_damage;
        fire_rate = base_fire_rate;
        accuracy = base_accuracy;
        crit_chance = base_crit_chance;
        crit_multiplier = base_crit_multi;
    }

    public void SetWeaponStats()
    {
        var main = ps.main;
        var col = ps.collision;
        main.startSpeed = bullet_speed;
        //fire_rate = fire_rate / 100;

        //weapon_name = wng.generated_weapon_name;

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
    
    

    void FixedUpdate () {
        //weapon_name = wng.generated_weapon_name;
    }
}
