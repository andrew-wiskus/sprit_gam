using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_SludgeEffect : MonoBehaviour {

    [SerializeField] private float m_slow_factor;
    [SerializeField] private float m_damage_amount;
    [SerializeField] private float m_damage_rate;
    [SerializeField] private float m_damage_delay;
    private float default_speed;
    private PlayerMovement m_player_movement;
    private PlayerStatConfig m_player_stat;

	// Use this for initialization
	void Start () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_player_movement = other.GetComponentInChildren<PlayerMovement>();
            m_player_stat = other.GetComponentInChildren<PlayerStatConfig>();
            default_speed = m_player_movement.m_default_speed;
            
            m_player_movement.m_default_speed /= m_slow_factor;

            InvokeRepeating("DrainLife", m_damage_delay, m_damage_rate);
        }
    }

    void DrainLife()
    {
            m_player_stat.current_health -= m_damage_amount;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_player_movement.m_default_speed = default_speed;
            CancelInvoke("DrainLife");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
