using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_SludgeEffect : MonoBehaviour {

    [SerializeField] private float m_slow_amount;
    private float default_speed;
    private PlayerMovement m_player;

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_player = other.GetComponentInChildren<PlayerMovement>();
            default_speed = m_player.m_default_speed;

            m_player.m_default_speed -= m_slow_amount;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_player.m_default_speed = default_speed;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
