using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickButtonMap : MonoBehaviour {

    [SerializeField] GunController m_gun_controller;

	void Update () {

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
    }
}
