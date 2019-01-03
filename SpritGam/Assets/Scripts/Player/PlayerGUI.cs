using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGUI : MonoBehaviour {


    private ParticleWeaponConfig pwc;
    private PlayerStatConfig playerStat;
    private WeaponStatConfig weaponStat;

    [SerializeField] private Image m_mana_fill_image;
    [SerializeField] private Text m_mana_text;
    [SerializeField] private Text m_reload_text;

    [SerializeField] private Image m_hp_fill_image;
    [SerializeField] private Text m_hp_text;
    

    void Start () {
        playerStat = GameObject.Find("Player").GetComponentInChildren<PlayerStatConfig>();
        weaponStat = GameObject.Find("Player").GetComponentInChildren<WeaponStatConfig>();
        pwc = GameObject.Find("Player").GetComponentInChildren<ParticleWeaponConfig>();
        UpdateGUI();
    }

    void UpdateGUI()
    {
        m_mana_text.text = playerStat.current_mana.ToString() + " / " + playerStat.mana_capacity.ToString();
        m_hp_text.text = playerStat.current_health.ToString() + " / " + playerStat.health_capacity.ToString();
        m_mana_fill_image.fillAmount = playerStat.current_mana / playerStat.mana_capacity;
        m_hp_fill_image.fillAmount = playerStat.current_health / playerStat.health_capacity;

        if (playerStat.current_mana - weaponStat.mana_cost_per_shot <= 0)
        {
            m_reload_text.enabled = true;
        }
        else
        {
            m_reload_text.enabled = false;
        }
    }
	
	void FixedUpdate()
    {
        UpdateGUI();
    }
}
