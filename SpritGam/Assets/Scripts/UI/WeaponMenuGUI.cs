using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponMenuGUI : MonoBehaviour {

    private WeaponStatConfig wsc;

    [SerializeField] Text w_weapon_name;
    [SerializeField] Image w_weapon_image;
    [SerializeField] Text w_damage_num;
    [SerializeField] Text w_fireRate_num;
    [SerializeField] Text w_fireType_num;
    [SerializeField] Text w_accuracy_num;
    [SerializeField] Text w_critChance_num;
    [SerializeField] Text w_critDamage_num;
    [SerializeField] public Image b_bullet_image;

    [SerializeField] Text b_manaCost_num;
    //[SerializeField] Text b_damage_num;
    //[SerializeField] Text b_bulletSpeed_num;
    //[SerializeField] Text b_ricochetCount_num;

    [SerializeField] Image[] chipMod_images;
    [SerializeField] Text[] chipModOne_effects;
    [SerializeField] Text[] chipModTwo_effects;
    [SerializeField] Text[] chipModThree_effects;

    // Use this for initialization
    void OnEnable () {
        wsc = GameObject.Find("config: weapon").GetComponent<WeaponStatConfig>();
        ResetStrings();
        w_weapon_image.sprite = GameObject.Find("Weapon").GetComponent<SpriteRenderer>().sprite;
        SetChipModDisplay();
        SetWeaponStatDisplay();
    }

    private void ResetStrings()
    {
        for (int i = 0; i < chipModOne_effects.Length; i++)
        {
            chipModOne_effects[i].text = "";
        }

        for (int i = 0; i < chipModTwo_effects.Length; i++)
        {
            chipModTwo_effects[i].text = "";
        }

        for (int i = 0; i < chipModThree_effects.Length; i++)
        {
            chipModThree_effects[i].text = "";
        }
    }

    void SetChipModDisplay()
    {
        ChipMod chip_one = wsc.chip_mods[0].GetComponent<ChipMod>();
        ChipMod chip_two = wsc.chip_mods[1].GetComponent<ChipMod>();
        ChipMod chip_three = wsc.chip_mods[2].GetComponent<ChipMod>();

        chipMod_images[0].sprite = wsc.chip_mods[0].GetComponent<SpriteRenderer>().sprite;
        chipMod_images[1].sprite = wsc.chip_mods[1].GetComponent<SpriteRenderer>().sprite;
        chipMod_images[2].sprite = wsc.chip_mods[2].GetComponent<SpriteRenderer>().sprite;

        for (int i = 0; i < chip_one.chipModStats.Length; i++)
        {
            chipModOne_effects[i].text = chip_one.chipModStats[i].type + " +" + chip_one.chipModStats[i].increase_amount.ToString();
        }

        for (int i = 0; i < chip_two.chipModStats.Length; i++)
        {
            chipModTwo_effects[i].text = chip_two.chipModStats[i].type + " +" + chip_two.chipModStats[i].increase_amount.ToString();
        }

        for (int i = 0; i < chip_three.chipModStats.Length; i++)
        {
            chipModThree_effects[i].text = chip_three.chipModStats[i].type + " +" + chip_three.chipModStats[i].increase_amount.ToString();
        }
        
    }

    void SetWeaponStatDisplay()
    {
        w_weapon_name.text = wsc.weapon_name.ToString();
        
        w_damage_num.text = wsc.damage.ToString();
        w_fireRate_num.text = wsc.fire_rate.ToString();
        w_fireType_num.text = wsc.fire_type;
        w_accuracy_num.text = wsc.accuracy.ToString();
        w_critChance_num.text = wsc.crit_chance.ToString();
        w_critDamage_num.text = wsc.crit_multiplier.ToString();
    }

    void SetWeaponNameDisplay()
    {
        w_weapon_name.text = wsc.weapon_name.ToString();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //SetWeaponStatDisplay();
        //SetChipModDisplay();
        SetWeaponNameDisplay();
    }
}
