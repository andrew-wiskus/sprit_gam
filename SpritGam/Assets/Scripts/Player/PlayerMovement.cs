using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStatConfig playerStat;

    private Rigidbody2D m_rigid_body;
    public float m_default_speed;
    public float m_sprint_speed;
    [SerializeField] private float m_velocity_lerp_value = 0.8f;
    [SerializeField] private float m_left_stick_dead_zone = 0.2f;
    [SerializeField] private float m_run_speed = 5.0f;

    private bool m_is_sprinting = false;
    private bool m_is_moving = false;
    private float m_movement_angle = 0.0f;
    private float m_magnitude = 0.0f;



    // PUBLIC

    public bool PlayerIsMoving { get { return m_is_moving; } }
    public bool PlayerIsSprinting { get { return m_is_sprinting; } }
    public float Angle { get { return m_movement_angle; } }
    public float Magnitude { get { return m_magnitude; } }

    private void Start()
    {
        playerStat = GetComponent<PlayerStatConfig>();
        m_rigid_body = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        m_default_speed = m_run_speed;
        m_sprint_speed = m_default_speed * 1.5f;
    }

    public void ToggleSprint(bool? is_sprinting)
    {
        if (is_sprinting.HasValue)
        {
            m_is_sprinting = (bool)is_sprinting;
        }
        else
        {
            m_is_sprinting = !m_is_sprinting;
        }
    }

    // END;

    private bool is_paused = false;

    public void Pause(bool shouldPause)
    {
        is_paused = shouldPause;
        move_player_rigid_body(0);
    }

    private void FixedUpdate()
    {
        if (is_paused)
        {
            return;
        }

        float speed = m_is_sprinting ? m_sprint_speed : m_default_speed;

        move_player_rigid_body(speed);
        set_player_movement_boolean();

        m_magnitude = movement_magnitude();
        m_movement_angle = get_adjusted_input_angle();
    }

    private float movement_magnitude()
    {
        float verticle = ControllerInput.RightStickVertical();
        float horizontal = ControllerInput.RightStickHorizontal();
        return Mathf.Clamp01(new Vector2(horizontal, verticle).magnitude);
    }

    private void set_player_movement_boolean()
    {
        Vector2 movement_vector = new Vector2(ControllerInput.LeftStickHorizontal(), ControllerInput.LeftStickVertical());
        bool player_is_moving = (Mathf.Clamp01(movement_vector.magnitude)) > m_left_stick_dead_zone;
        m_is_moving = player_is_moving;
    }

    private void move_player_rigid_body(float speed)
    {
        float x_velocity = Mathf.Lerp(0, ControllerInput.LeftStickHorizontal() * speed, m_velocity_lerp_value);
        float y_velocity = Mathf.Lerp(0, ControllerInput.LeftStickVertical() * speed, m_velocity_lerp_value);

        m_rigid_body.velocity = new Vector2(x_velocity, y_velocity);
    }

    private float get_adjusted_input_angle()
    {
        float angle = Controller.GetLeftAnalogStickAngle();

        if (angle < 0)
        {
            return angle * -1.0f;
        }
        else if (angle > 0)
        {
            return (90.0f - angle) + 270.0f;
        }
        else
        {
            return angle;
        }
    }
}
