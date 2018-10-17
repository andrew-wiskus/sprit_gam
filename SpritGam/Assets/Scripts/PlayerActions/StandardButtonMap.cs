using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardButtonMap : MonoBehaviour {

    [SerializeField] Animator weaponAnimator;
    public WeaponAudio m_weaponAudio;
    

	// Use this for initialization
	void Awake () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool x_pressed = ControllerInput.Pressed_X() != false;

        if (x_pressed == true)
        {
            m_weaponAudio.reloadTommyGun();
            weaponAnimator.Play("TommyGun_Reload");
        }
    }
}
