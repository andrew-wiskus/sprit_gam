using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickButtonMap : MonoBehaviour {

    [SerializeField] GunController m_gun_controller;

	void Update () {

        if (ControllerInput.Pressed_X(Key.DOWN))
        {
            m_gun_controller.ReloadWeapon();
        }
    }
}
