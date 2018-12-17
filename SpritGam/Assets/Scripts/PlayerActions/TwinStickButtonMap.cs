using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickButtonMap : MonoBehaviour
{

    [SerializeField] TwinStickMovement tsm;
    [SerializeField] GunController m_gun_controller;
    [SerializeField] PlayerWeaponStance playerWeaponStance;
    [SerializeField] VibrationController gpc;
    [SerializeField] InventoryController m_inventory_controller;
    [SerializeField] CrossHairController m_cross_hair_controller;

    void Update()
    {
        if (m_inventory_controller.inventoryIsShowing())
        {
            if (ControllerInput.Pressed_StartButton(Key.DOWN))
            {
                m_inventory_controller.ShowInventory(false);
            }


            return;
        }

        /// PRESS X
        /// (Reload weapon)
        if (ControllerInput.Pressed_X(Key.DOWN))
        {
            m_gun_controller.Reload();
        }


        /// PRESS B
        /// (Toggle fire mode)
        if (ControllerInput.Pressed_B(Key.DOWN))
        {
            m_gun_controller.ToggleFireStyle();
        }


        /// PRESS Y
        /// (Change weapon)
        if (ControllerInput.Pressed_Y(Key.DOWN))
        {
            //playerWeaponStance.ToggleEquippedWeapon();

            // TODO: Toggle gun controlelr to chance m_current_weapon, on change weapon: set the current weapons GunStance property (to be made)
            // ex: (not written yet)
            // in GunController:
            // m_current_weapon = foo;
            // m_current_weapon.SetWeaponStanceAnimation();
        }

        /// PRESS A
        /// (Toggle weapon attachment)
        if (ControllerInput.Pressed_A(Key.DOWN))
        {
        }


        /// PRESS LT
        /// (ADS)
        if (ControllerInput.LeftTrigger() >= 0.2)
        {
            m_cross_hair_controller.ToggleADS(true);
        }
        else
        {
            m_cross_hair_controller.ToggleADS(false);
        }

        /// PRESS L3
        /// (Sprint)
        if (ControllerInput.Pressed_L3(Key.IS_PRESSED) && m_cross_hair_controller.StatusOfADS() == false)
        {
            tsm.m_is_sprinting = true;
        }
        else
        {
            tsm.m_is_sprinting = false;
        }

        if(ControllerInput.Pressed_StartButton(Key.DOWN))
        {
            m_inventory_controller.ShowInventory(true);
        }

    }

}
