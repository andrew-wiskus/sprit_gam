using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class TwinStickMovement : MonoBehaviour
{

    [SerializeField] private Animator m_playermovement_animator;

    //[SerializeField] private Animator m_feet_animator;
    [SerializeField] private Transform m_player_transform;
    [SerializeField] public float m_speed_multiplier;
    [SerializeField] public float m_sprint_speed;
    public bool m_is_sprinting = false;
    [SerializeField] public float m_ads_speed;
    public float m_default_speed;

    //[SerializeField] private GunController gc;
    //[SerializeField] private TwinStickButtonMap tsm;

    //[SerializeField] private GameObject feet;
    

    private Rigidbody2D m_rigid_body;
    private AudioSource m_audio_source;

    [SerializeField] private float m_left_stick_dead_zone;
    [SerializeField] private float m_right_stick_dead_zone;

    void Awake()
    {
        //gc = GetComponentInChildren<GunController>();
        m_default_speed = m_speed_multiplier;
        m_rigid_body = GetComponent<Rigidbody2D>();
        m_audio_source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
            m_rigid_body.velocity = new Vector2(Mathf.Lerp(0, ControllerInput.LeftStickHorizontal() * m_speed_multiplier, 0.8f),
            Mathf.Lerp(0, ControllerInput.LeftStickVertical() * m_speed_multiplier, 0.8f));
        
    }

    public void SetPlayerSpeed()
    {
        if (m_is_sprinting == true)
        {
            //gc.is_ADS = false;
            m_speed_multiplier = m_sprint_speed;
            m_playermovement_animator.speed = 1.5f;

        //} else if (gc.is_ADS == true)
        //{
        //    m_is_sprinting = false;
       //     m_speed_multiplier = m_ads_speed;
        //    m_playermovement_animator.speed = 0.5f;
        } else
        {
            m_speed_multiplier = m_default_speed;
            m_playermovement_animator.speed = 1.0f;
        }
    }
    

    void Update()
    {
        //gc = GetComponentInChildren<GunController>();

        SetPlayerSpeed();

        bool player_is_walking = (Mathf.Clamp01(new Vector2(ControllerInput.LeftStickHorizontal(), ControllerInput.LeftStickVertical()).magnitude)) > m_left_stick_dead_zone;
        bool player_is_aiming = (Mathf.Clamp01(new Vector2(ControllerInput.RightStickHorizontal(), ControllerInput.RightStickVertical()).magnitude)) > m_right_stick_dead_zone;
        
        

        if (player_is_aiming)
        {
            float angle = Controller.GetRightAnalogStickAngle();
            m_player_transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        }

        if (player_is_walking)
        {
            float angle = Controller.GetLeftAnalogStickAngle();
            //feet.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));

            if (m_audio_source.isPlaying == false)
            {
                m_audio_source.Play();
            }

            m_playermovement_animator.Play("Player_Run Right");
        }

        if (player_is_walking == false)
        {
            m_playermovement_animator.Play("Player_Idle");
        }
        

    }
}