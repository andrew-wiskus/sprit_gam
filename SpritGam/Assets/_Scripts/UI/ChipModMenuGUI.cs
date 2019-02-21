using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[Serializable]
public class ChipModGUIObject
{
    // GUI Fields
    public Image chip_image;
    public Text[] chip_stat_text;
}


public class ChipModMenuGUI : MonoBehaviour {

    private ChipMod chipMod;
    public ChipModGUIObject chip_GUI;
    private WeaponMenuGUI weaponMenuGUI;
    private WeaponStatConfig weaponStatConfig;

    private ChipModInventoryGUI m_current_chip_inventoryGUI;
    private ChipModInventoryGUI m_highlighted_chip_inventoryGUI;
    private Button button;
    private ChipMod currentChipMod;
    private Image chip_sprite;


	void OnEnable () {
        weaponStatConfig = GameObject.Find("config: weapon").GetComponent<WeaponStatConfig>();

        m_highlighted_chip_inventoryGUI = GameObject.Find("ChipModInventory").GetComponent<ChipModInventoryGUI>();
        m_current_chip_inventoryGUI = GameObject.Find("ChipModInventory").GetComponent<ChipModInventoryGUI>();
        weaponMenuGUI = GetComponentInParent<WeaponMenuGUI>();
        button = GetComponentInChildren<Button>();

        //GameObject currentWeapon = GameObject.Find("config: weapon");
        currentChipMod = weaponMenuGUI.current_selected_chip.GetComponent<ChipMod>();

        Button[] buttons = GetComponentsInChildren<Button>();
        buttons[0].Select();

        CheckChipData();

        button.onClick.AddListener(SetAsCurrentChip);
	}

    void CheckChipData()
    {
        chipMod = GetComponent<ChipMod>();
        SetSprite();
        SetBlankChip();
        SetChipData();
        SetCurrentChipDisplay();
    }

    void SetBlankChip()
    {
        for (int i = 0; i < 3; i++)
        {
            m_current_chip_inventoryGUI.currentChipGUI.chip_stat_text[i].text = "";
            chip_GUI.chip_stat_text[i].text = "";
        }
    }

    void SetChipData()
    {

        for (int i = 0; i < chipMod.chipModStats.Length; i++)
        {
            chip_GUI.chip_stat_text[i].text = chipMod.chipModStats[i].type.ToString().Replace("_", " ").Replace("Chance", "%").Replace("Multiplier", "Dmg") + "  +" + chipMod.chipModStats[i].increase_amount.ToString().Replace("0.", ".");
        }
    }

    void SetSprite()
    {

        switch (chipMod.mod_rating)
        {
            case ModRating.GOLD:
                chip_GUI.chip_image.sprite = chipMod.gold_sprite;
                break;

            case ModRating.SILVER:
                chip_GUI.chip_image.sprite = chipMod.silver_sprite;
                break;

            case ModRating.BRONZE:
                chip_GUI.chip_image.sprite = chipMod.bronze_sprite;
                break;

            case ModRating.WHITE:
                chip_GUI.chip_image.sprite = chipMod.white_sprite;
                break;

            default:
                chip_sprite.sprite = null;
                break;
        }
        
    }

    void SetAsCurrentChip()
    {
        
        currentChipMod.mod_rating = chipMod.mod_rating;
        currentChipMod.chipModStats = chipMod.chipModStats;

        m_current_chip_inventoryGUI.currentChipGUI.chip_image.sprite = chip_GUI.chip_image.sprite;

        for (int i = 0; i < 3; i++)
        {
            m_current_chip_inventoryGUI.currentChipGUI.chip_stat_text[i].text = "";
        }

        for (int i = 0; i < currentChipMod.chipModStats.Length; i++)
        {
            m_current_chip_inventoryGUI.currentChipGUI.chip_stat_text[i].text = currentChipMod.chipModStats[i].type.ToString().Replace("_", " ").Replace("Chance", "%").Replace("Multiplier", "Dmg") + " +" +  currentChipMod.chipModStats[i].increase_amount.ToString().Replace("0.", ".");
        }



        //NullOldChipStats();
       // CalculateNewChipStats();
        weaponMenuGUI.CalculateStatIncreases();
        weaponMenuGUI.SetWeaponStatDisplay();
        weaponStatConfig.LogWeaponStats();
    }

    void NullOldChipStats()
    {
        //weaponStatConfig.LogWeaponStats();
        foreach (ChipModStat stat in currentChipMod.chipModStats)
        {
            switch (stat.type)
            {
                case ModType.Damage:
                     weaponStatConfig.damage -= stat.increase_amount;
                break;

                case ModType.Fire_Rate:
                    weaponStatConfig.fire_rate -= stat.increase_amount;
                break;

                case ModType.Accuracy:
                    weaponStatConfig.accuracy -= stat.increase_amount;
                break;

                case ModType.Crit_Chance:
                    weaponStatConfig.crit_chance -= stat.increase_amount;
                break;

                case ModType.Crit_Multiplier:
                    weaponStatConfig.crit_multiplier -= stat.increase_amount;
                break;
            }
        }
    }

    void CalculateNewChipStats()
    {
        foreach (ChipModStat stat in chipMod.chipModStats)
        {
            switch (stat.type)
            {
                case ModType.Damage:
                    weaponStatConfig.damage += stat.increase_amount;
                    break;

                case ModType.Fire_Rate:
                    weaponStatConfig.fire_rate += stat.increase_amount;
                    break;

                case ModType.Accuracy:
                    weaponStatConfig.accuracy += stat.increase_amount;
                    break;

                case ModType.Crit_Chance:
                    weaponStatConfig.crit_chance += stat.increase_amount;
                    break;

                case ModType.Crit_Multiplier:
                    weaponStatConfig.crit_multiplier += stat.increase_amount;
                    break;
            }
        }
    }


    void DisplaySelectedChip()
    {
        Debug.Log("selecting a chip");

        m_highlighted_chip_inventoryGUI.highlightedChipGUI.chip_image.sprite = chip_GUI.chip_image.sprite;
        for (int i = 0; i < currentChipMod.chipModStats.Length; i++)
        {
            m_highlighted_chip_inventoryGUI.currentChipGUI.chip_stat_text[i].text = currentChipMod.chipModStats[i].type.ToString().Replace("_", " ").Replace("Chance", "%").Replace("Multiplier", "Dmg") + "  +" + currentChipMod.chipModStats[i].increase_amount.ToString().Replace("0.", ".");

        }
    }

    void SetCurrentChipDisplay()
    {

        // clear stats
        for (int i = 0; i < 3; i++)
        {
            m_current_chip_inventoryGUI.currentChipGUI.chip_stat_text[i].text = "";
        }

        // set stats
        for (int i = 0; i < currentChipMod.chipModStats.Length; i++)
        {
            m_current_chip_inventoryGUI.currentChipGUI.chip_stat_text[i].text = currentChipMod.chipModStats[i].type.ToString().Replace("_", " ").Replace("Chance", "%").Replace("Multiplier", "Dmg") + "  +" + currentChipMod.chipModStats[i].increase_amount.ToString().Replace("0.", ".");

        }
    }


    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("on select");
        DisplaySelectedChip();
    }

    void FixedUpdate()
    {

    }

}
