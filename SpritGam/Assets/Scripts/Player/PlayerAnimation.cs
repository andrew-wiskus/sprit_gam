using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    [SerializeField] private PlayerAim m_player_aim;
    [SerializeField] private PlayerMovement m_player_movement;
    [SerializeField] private Animator m_movement_animator;
    [SerializeField] private float m_run_speed_multiplier = 4.0f;
    [SerializeField] private float m_walk_speed_multiplier = 2.5f;

    private string m_run_animation = "Player_Run Right";

    private void FixedUpdate()
    {
        set_run_animation_direction();
        set_run_animation_speed();
        play_movement_animation();
    }

    private void set_run_animation_direction()
    {
        if(m_player_aim.IsAiming == false && m_player_movement.PlayerIsMoving == true)
        {
            // set idle animation for aiming here
            // (player is aiming but not moving);

            return;
        }

        float angle = m_player_aim.Angle;
        set_animation_string_for_angle(angle);

    }

    private void set_run_animation_speed()
    {
        if(m_player_movement.PlayerIsSprinting)
        {
            m_movement_animator.speed = m_run_speed_multiplier;
        }
        else {
            m_movement_animator.speed = m_walk_speed_multiplier;
        }
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
            // TODO: Set player idle for left & right where we set `m_run_animation`
            // base this off of player_aim.angle; since he is idle and movement wont have an angle;
            m_movement_animator.Play("Player_Idle");
        }
    }

    private void set_animation_string_for_angle(float angle)
    {
        // TODO: Set for all angles of character animations;

        if (angle >= 180.0f)
        {
            m_run_animation = "Player_Run Left";
        }
        else
        {
            m_run_animation = "Player_Run Right";
        }
    }
}
