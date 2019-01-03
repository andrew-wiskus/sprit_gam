using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour {

    private PlayerAim playerAim;
    private GameObject weapon;
    

	// Use this for initialization
	void Start () {
        playerAim = GetComponent<PlayerAim>();
        weapon = GameObject.Find("Player/Weapon");

        Quaternion defaultRotation = Quaternion.Euler(0f, 0f, 0f);
        weapon.transform.rotation = defaultRotation;
	}

    void FixedUpdate()
    {
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, -playerAim.m_player_aim_angle + 90);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
