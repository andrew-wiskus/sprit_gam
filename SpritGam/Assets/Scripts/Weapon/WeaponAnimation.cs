using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour {

    [SerializeField] PlayerAnimation m_player_animation;

    [SerializeField] public GameObject m_weapon;
    [SerializeField] public GameObject m_player;

    private SpriteRenderer m_weapon_sprite;
    private SpriteRenderer m_player_sprite;
    
	// Use this for initialization
	void Start () {
        m_weapon_sprite = m_weapon.GetComponent<SpriteRenderer>();
        m_player_sprite = m_player.GetComponent<SpriteRenderer>();
	}

    void FixedUpdate()
    {
        string direction = m_player_animation.direction;

        if (direction == "Up" || direction == "UpRight" || direction == "UpLeft")
        {
            // gun sorting layer UNDER
           m_weapon_sprite.sortingOrder = m_player_sprite.sortingOrder - 1;
        } else
        {
            // gun sorting layer OVER
            m_weapon_sprite.sortingOrder = m_player_sprite.sortingOrder + 1;
        }
    }
}
