using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public bool IsAiming { get { return m_player_is_aiming; } }
    public float Angle { get { return m_player_aim_angle; } }
    public float Magnitude { get { return m_aim_magnitude; } }

    private float defined_direction;
    [SerializeField] private float m_right_stick_dead_zone = 0.2f;

    private bool m_player_is_aiming;
    public float m_player_aim_angle;
    private float m_aim_magnitude;
    private bool is_paused = false;

    public void Pause(bool shouldPause)
    {
        is_paused = shouldPause;
    }

    private void FixedUpdate()
    {
        if(is_paused)
        {
            return;
        }

        m_aim_magnitude = aim_magnitude();
        m_player_is_aiming = m_aim_magnitude > m_right_stick_dead_zone;
        m_player_aim_angle = get_adjusted_aim_angle();
    }

    private float aim_magnitude()
    {
        float verticle = ControllerInput.RightStickVertical();
        float horizontal = ControllerInput.RightStickHorizontal();
        return Mathf.Clamp01(new Vector2(horizontal, verticle).magnitude);
    }

    private float get_adjusted_aim_angle()
    {
        float angle = Controller.GetRightAnalogStickAngle();
        //
        //Debug.Log("INIT X: " + angle);

        float x = angle - 360.0f;

        //Debug.Log("X ANGLE: " + x);


        if (Magnitude < m_right_stick_dead_zone)
        {
            return defined_direction;
        } else
        {
            defined_direction = x * -1.0f;
            return defined_direction;
        }

        //return x >= 0.0f ? x : x * -1.0f;
        
    }
}
