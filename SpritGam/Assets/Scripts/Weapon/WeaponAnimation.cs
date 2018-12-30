using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour {

    [SerializeField] PlayerAnimation m_player_animation;

    [SerializeField] public GameObject m_weapon;
    [SerializeField] public GameObject m_player;

    private SpriteRenderer m_weapon_sprite;
    private SpriteRenderer m_player_sprite;

    private string direction = "";


    void Start () {
        m_weapon_sprite = m_weapon.GetComponent<SpriteRenderer>();
        m_player_sprite = m_player.GetComponent<SpriteRenderer>();
	}

    void FixedUpdate() {
        direction = m_player_animation.direction;

        set_weapon_sorting_layer();
        set_weapon_image_direction();
    }

    void set_weapon_sorting_layer()
    {
        if (direction == "Up" || direction == "UpRight" || direction == "UpLeft")
        {
            // gun_sorting_layer UNDER
            m_weapon_sprite.sortingOrder = m_player_sprite.sortingOrder - 1;
        }
        else
        {
            // gun_sorting_layer OVER
            m_weapon_sprite.sortingOrder = m_player_sprite.sortingOrder + 1;

        }
    }

    void set_weapon_image_direction()
    {
        if (direction == "UpLeft" || direction == "Left" || direction == "Down")
        {
            m_weapon_sprite.flipY = true;
        } else
        {
            m_weapon_sprite.flipY = false;
        }
    }
}
