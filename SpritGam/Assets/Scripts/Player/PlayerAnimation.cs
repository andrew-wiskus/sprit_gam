using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    [SerializeField] private PlayerAim m_player_aim;
    [SerializeField] private PlayerMovement m_player_movement;
    [SerializeField] private Animator m_movement_animator;

    private string m_run_animation = "Player_Run Right";
    private string m_idle_animation = "Player_Idle Right";

    private void FixedUpdate()
    {
        set_run_animation_direction();
        set_run_animation_speed();
        play_movement_animation();
    }

    private void set_run_animation_direction()
    {
        if(m_player_aim.IsAiming == false)
        {
            return;
        }

        float angle = m_player_aim.Angle;
        set_animation_string_for_angle(angle);

    }

    private void set_run_animation_speed()
    {
        float run_speed = 1.5f;
        float walk_speed = 1.0f;
        float animation_speed = m_player_movement.PlayerIsSprinting ? run_speed : walk_speed;

        m_movement_animator.speed = animation_speed;
    }

    private void play_movement_animation()
    {
        if(m_player_aim.IsAiming == false)
        {
            set_animation_string_for_angle(m_player_movement.Angle);
        }
        if(m_player_movement.PlayerIsMoving)
        {
            m_movement_animator.Play(m_run_animation);
        }
        else
        {
            // TODO: Set player idle for left & right where we set `m_run_animation`;
            m_movement_animator.Play(m_idle_animation);
        }
    }

    private void set_animation_string_for_angle(float angle)
    {
        string direction = "";

        if (angle <= 180.0f)
        {
            direction = "Right";
        }
        else
        {
            direction = "Left";
        }

        m_idle_animation = "Player_Idle " + direction; 
        m_run_animation = "Player_Run " + direction;
    }
}
