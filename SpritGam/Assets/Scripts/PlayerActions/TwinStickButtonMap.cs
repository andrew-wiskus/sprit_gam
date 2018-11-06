﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickButtonMap : MonoBehaviour {

    [SerializeField] GunController m_gun_controller;
    [SerializeField] PlayerWeaponStance playerWeaponStance;
    [SerializeField] GamepadController gpc;

    private void Awake ()
    {
        
    }
    

	void Update () {
        

        /// PRESS X
        /// (Reload weapon)
        if (ControllerInput.Pressed_X(Key.DOWN))
        {
            
            if (m_gun_controller.m_is_shotgun == true)
            {
                m_gun_controller.ReloadShotgun();
            } else if(m_gun_controller.m_is_dual == true)
            {
                m_gun_controller.ReloadDualWeapon();
            } else
            {
                m_gun_controller.ReloadWeapon();
            }
        }


        /// PRESS B
        /// (Toggle fire mode)
        if(ControllerInput.Pressed_B(Key.DOWN))
        {
            m_gun_controller.ToggleFireStyle();
        }


        /// PRESS Y
        /// (Change weapon)
        if(ControllerInput.Pressed_Y(Key.DOWN))
        {
            playerWeaponStance.ToggleEquippedWeapon();
        }

        m_gun_controller = playerWeaponStance.currentWeapon.GetComponent<GunController>();


        /// PRESS A
        /// (Toggle weapon attachment)
        if (ControllerInput.Pressed_A(Key.DOWN))
        {
            m_gun_controller.ToggleAttachment();
        }


        /// PRESS LT
        /// (ADS)
        if (ControllerInput.LeftTrigger() >= 0.2)
        {
            StartCoroutine(m_gun_controller.toggleADS_ON());
        } else
        {
            m_gun_controller.toggleADS_OFF();
        }



        }
    
}
