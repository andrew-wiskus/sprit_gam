using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[Serializable]
public class BulletGUIObject
{
    // GUI Fields
    public Image bullet_image;
    public GameObject bullet_particleObject;
    public ParticleSystem bullet_particleSystem;
    public Text bullet_name_text;
    public Text bullet_manaCost_text;
    public Text bullet_speed_text;
    public Text bullet_description_text;
    public Text[] bullet_bonusEffects_text;
}

public class BulletMenuGUI : MonoBehaviour ,  ISelectHandler {

    private BulletModule bulletModule;
    public BulletGUIObject bulletGUI;
    private BulletGenerator bulletGenerator;
    //public bool is_current;
    //public bool is_new;
    [HideInInspector] public GameObject highlighted_bullet;
    private BulletInventoryGUI m_highlightedBulletGUI;
    private BulletInventoryGUI m_currentBulletGUI;
    private Button button;
    private BulletModule currentBulletModule;


    // Use this for initialization
    void OnEnable () {
        m_highlightedBulletGUI = GameObject.Find("BulletInventory").GetComponent<BulletInventoryGUI>();
        m_currentBulletGUI = GameObject.Find("BulletInventory").GetComponent<BulletInventoryGUI>();
        bulletGenerator = GameObject.Find("BulletGenerator").GetComponent<BulletGenerator>();
        button = GetComponent<Button>();

        GameObject currentWeapon = GameObject.Find("config: weapon");
        currentBulletModule = currentWeapon.GetComponent<BulletModule>();

        CheckBulletData();

        button.onClick.AddListener(SetAsCurrentBullet);
    }

    void CheckBulletData()
    {
        bulletModule = GetComponent<BulletModule>();
        SetBlankBullet();
        SetBulletData();
        SetCurrentBulletDisplay();
    }

    void SetBulletData()
    {
        var particles = bulletGUI.bullet_particleSystem.trails;
        var main = bulletGUI.bullet_particleSystem.main;

        bulletGenerator.GenerateNewBullet();
        bulletModule.bullet.bullet_name = bulletGenerator.generated_bullet_name;

        bulletGUI.bullet_name_text.text = bulletModule.bullet.bullet_name;
        bulletGUI.bullet_image.sprite = bulletModule.bullet.bullet_sprite;
        bulletGUI.bullet_image.color = bulletModule.bullet.bullet_color;
        main.startColor = bulletModule.bullet.trail_gradient;
        bulletGUI.bullet_manaCost_text.text = bulletModule.bullet.mana_cost_per_shot.ToString();
        bulletGUI.bullet_speed_text.text = bulletModule.bullet.bullet_speed.ToString();
        bulletGUI.bullet_description_text.text = bulletModule.bullet.special_effect.effect_description;

        for (int i = 0; i < bulletModule.bullet.bullet_bonus_stats.Length; i++)
        {
            bulletGUI.bullet_bonusEffects_text[i].text = bulletModule.bullet.bullet_bonus_stats[i].bonus_stats.ToString() + " +" + bulletModule.bullet.bullet_bonus_stats[i].stat_increase_amount.ToString();
        }
    }

    void SetBlankBullet()
    {
        var particles = m_highlightedBulletGUI.highlightedBulletGUI.bullet_particleSystem.trails;
        var main = m_highlightedBulletGUI.highlightedBulletGUI.bullet_particleSystem.main;

        m_highlightedBulletGUI.highlightedBulletGUI.bullet_image.sprite = null;
        m_highlightedBulletGUI.highlightedBulletGUI.bullet_image.color = Color.white;
        main.startColor = new Color(0, 0 , 0, 0);
        m_highlightedBulletGUI.highlightedBulletGUI.bullet_name_text.text = "";
        m_highlightedBulletGUI.highlightedBulletGUI.bullet_manaCost_text.text = "";
        m_highlightedBulletGUI.highlightedBulletGUI.bullet_speed_text.text = "";
        m_highlightedBulletGUI.highlightedBulletGUI.bullet_description_text.text = "";

        for (int i = 0; i < m_highlightedBulletGUI.highlightedBulletGUI.bullet_bonusEffects_text.Length; i++)
        {
            m_highlightedBulletGUI.highlightedBulletGUI.bullet_bonusEffects_text[i].text = "";
        }
    }



    void DisplaySelectedBullet()
    {
            var particles = m_highlightedBulletGUI.highlightedBulletGUI.bullet_particleSystem.trails;
            var main = m_highlightedBulletGUI.highlightedBulletGUI.bullet_particleSystem.main;


            m_highlightedBulletGUI.highlightedBulletGUI.bullet_image.sprite =  bulletModule.bullet.bullet_sprite;
            m_highlightedBulletGUI.highlightedBulletGUI.bullet_image.color = bulletModule.bullet.bullet_color;
            main.startColor = bulletModule.bullet.trail_gradient;
            m_highlightedBulletGUI.highlightedBulletGUI.bullet_name_text.text = bulletModule.bullet.bullet_name;
            m_highlightedBulletGUI.highlightedBulletGUI.bullet_manaCost_text.text = bulletModule.bullet.mana_cost_per_shot.ToString();
            m_highlightedBulletGUI.highlightedBulletGUI.bullet_speed_text.text = bulletModule.bullet.bullet_speed.ToString();
            m_highlightedBulletGUI.highlightedBulletGUI.bullet_description_text.text = bulletModule.bullet.special_effect.effect_description;

            for (int i = 0; i < bulletModule.bullet.bullet_bonus_stats.Length; i++)
            {
            m_highlightedBulletGUI.highlightedBulletGUI.bullet_bonusEffects_text[i].text = bulletModule.bullet.bullet_bonus_stats[i].bonus_stats.ToString() + " +" + bulletModule.bullet.bullet_bonus_stats[i].stat_increase_amount.ToString();
            }
    }

    void SetAsCurrentBullet()
    {

        currentBulletModule.bullet.bullet_name = bulletModule.bullet.bullet_name;
        currentBulletModule.bullet.bullet_sprite = bulletModule.bullet.bullet_sprite;
        currentBulletModule.bullet.bullet_color = bulletModule.bullet.bullet_color;
        currentBulletModule.bullet.trail_gradient = bulletModule.bullet.trail_gradient;
        currentBulletModule.bullet.mana_cost_per_shot = bulletModule.bullet.mana_cost_per_shot;
        currentBulletModule.bullet.special_effect.effect_type = bulletModule.bullet.special_effect.effect_type;
        currentBulletModule.bullet.special_effect.effect_chance = bulletModule.bullet.special_effect.effect_chance;
        currentBulletModule.bullet.special_effect.effect_description = bulletModule.bullet.special_effect.effect_description;
        currentBulletModule.bullet.bullet_bonus_stats = bulletModule.bullet.bullet_bonus_stats;

        GameObject.Find("Firepoint").GetComponentInChildren<ParticleWeaponConfig>().SetParticleData();

        SetCurrentBulletDisplay();
        //CheckBulletData();
    }

    void SetCurrentBulletDisplay()
    {
        var particles = m_currentBulletGUI.currentBulletGUI.bullet_particleSystem.trails;


        m_currentBulletGUI.currentBulletGUI.bullet_image.sprite = bulletModule.bullet.bullet_sprite;
        m_currentBulletGUI.currentBulletGUI.bullet_image.color = bulletModule.bullet.bullet_color;
        particles.colorOverTrail = bulletModule.bullet.trail_gradient;
        m_currentBulletGUI.currentBulletGUI.bullet_name_text.text = bulletModule.bullet.bullet_name;
        m_currentBulletGUI.currentBulletGUI.bullet_manaCost_text.text = bulletModule.bullet.mana_cost_per_shot.ToString();
        m_currentBulletGUI.currentBulletGUI.bullet_speed_text.text = bulletModule.bullet.bullet_speed.ToString();
        m_currentBulletGUI.currentBulletGUI.bullet_description_text.text = bulletModule.bullet.special_effect.effect_description;

        for (int i = 0; i < bulletModule.bullet.bullet_bonus_stats.Length; i++)
        {
            bulletGUI.bullet_bonusEffects_text[i].text = bulletModule.bullet.bullet_bonus_stats[i].bonus_stats.ToString() + " +" + bulletModule.bullet.bullet_bonus_stats[i].stat_increase_amount.ToString();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        DisplaySelectedBullet();
        //highlighted_bullet = gameObject;

    }
	
	void FixedUpdate () {
        
	}
}
