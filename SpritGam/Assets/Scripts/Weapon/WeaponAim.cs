using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour {

    [SerializeField] PlayerAim m_playeraim;
    private GameObject weapon;
    

	// Use this for initialization
	void Start () {
        weapon = GameObject.Find("Weapon");

        Quaternion defaultRotation = Quaternion.Euler(0f, 0f, 0f);
        weapon.transform.rotation = defaultRotation;
	}

    void FixedUpdate()
    {
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, -m_playeraim.m_player_aim_angle + 90);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
