using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class TwinStickMovement : MonoBehaviour
{

    [SerializeField] private Animator m_animator;
    [SerializeField] private Transform m_player_transform;
    [SerializeField] private float m_speed_multiplier;

    // PAT
    [SerializeField] private Animator m_weapon_animator;

    private Rigidbody2D m_rigid_body;
    private AudioSource m_audio_source;

    void Awake()
    {
        m_rigid_body = GetComponent<Rigidbody2D>();
        m_audio_source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        m_rigid_body.velocity = new Vector2(Mathf.Lerp(0, ControllerInput.LeftStickHorizontal() * m_speed_multiplier, 0.8f),
            Mathf.Lerp(0, ControllerInput.LeftStickVertical() * m_speed_multiplier, 0.8f));
    }

    void Update()
    {
        bool player_is_walking = ControllerInput.LeftStickHorizontal() != 0 || ControllerInput.LeftStickVertical() != 0;
        bool player_is_aiming = ControllerInput.RightStickHorizontal() != 0 || ControllerInput.RightStickVertical() != 0;

        // PAT
        bool x_pressed = ControllerInput.Pressed_X() != false;

        if (player_is_aiming)
        {
            float angle = Controller.GetRightAnalogStickAngle();
            m_player_transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        }

        if (player_is_walking)
        {
            if (m_audio_source.isPlaying == false)
            {
                m_audio_source.Play();
            }

            m_animator.Play("Walk");
        }

        if (player_is_walking == false)
        {
            m_animator.Play("Idle");
        }

        // PAT
        if (x_pressed == true)
        {
            m_weapon_animator.Play("TommyGun_Reload");
        }

    }
}