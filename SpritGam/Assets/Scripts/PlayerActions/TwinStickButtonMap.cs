using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickButtonMap : MonoBehaviour {

    [SerializeField] GunController m_gun_controller;
    [SerializeField] GunController m_primary_weapon;
    [SerializeField] GunController m_secondary_weapon;
    private GunController currentWeapon;

    [SerializeField] GameObject primaryWeapon;
    [SerializeField] GameObject secondaryWeapon;

    [SerializeField] GameObject L_Hand;
    [SerializeField] GameObject R_Hand;

    private void Awake ()
    {
        currentWeapon = m_primary_weapon;
        m_gun_controller = currentWeapon;

        primaryWeapon.SetActive(true);
        secondaryWeapon.SetActive(false);
    }

	void Update () {

        m_gun_controller = currentWeapon;

        // (TEMPORARY UNTIL I FIX HANDS TO ATTACH TO TOMMY GUN WEAPON)
        if (primaryWeapon.activeSelf == true)
        {
            L_Hand.SetActive(true);
            R_Hand.SetActive(true);
        }
        else
        {
            L_Hand.SetActive(false);
            R_Hand.SetActive(false);
        }

        if (ControllerInput.Pressed_X(Key.DOWN))
        {
            
            if (m_gun_controller.m_is_shotgun == true)
            {
                m_gun_controller.ReloadShotgun();
            } else
            {
                m_gun_controller.ReloadWeapon();
            }
        }

        if(ControllerInput.Pressed_B(Key.DOWN))
        {
            m_gun_controller.ToggleFireStyle();
        }

        if(ControllerInput.Pressed_Y(Key.DOWN))
        {
            // SWITCH WEAPON
            if (currentWeapon == m_primary_weapon)
            {
                secondaryWeapon.SetActive(true);
                primaryWeapon.SetActive(false);
                currentWeapon = m_secondary_weapon;
            } else
            {
                secondaryWeapon.SetActive(false);
                primaryWeapon.SetActive(true);
                currentWeapon = m_primary_weapon;
            }
        }
    }
}
