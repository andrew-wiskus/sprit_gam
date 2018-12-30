using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public bool IsAiming { get { return m_player_is_aiming; } }
    public float Angle { get { return m_player_aim_angle; } }
    public float Magnitude { get { return m_aim_magnitude; } }

    [SerializeField] private float m_right_stick_dead_zone = 0.2f;

    private bool m_player_is_aiming;
    public float m_player_aim_angle;
    private float m_aim_magnitude;

    private void FixedUpdate()
    {
        m_player_aim_angle = get_adjusted_aim_angle();
        m_aim_magnitude = aim_magnitude();
        m_player_is_aiming = m_aim_magnitude > m_right_stick_dead_zone;
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
        float x = angle - 360.0f;
        return x >= 0.0f ? x : x * -1.0f;
    }
}
