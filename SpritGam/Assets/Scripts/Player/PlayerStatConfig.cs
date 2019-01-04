using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatConfig : MonoBehaviour {

    public float run_speed;
    public float health_capacity;
    public float mana_capacity;

    public float current_health;
    public float current_mana;

    public Sprite current_weapon;
    

	void Start () {
        SetPlayerStats();
        current_health = health_capacity;
        current_mana = mana_capacity;
	}

    void SetPlayerStats()
    {

    }

    void UpdatePlayerVitals()
    {

    }
	
	void FixedUpdate()
    {
        //UpdatePlayerVitals();
    }
}
