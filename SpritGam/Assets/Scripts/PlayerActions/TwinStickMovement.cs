using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class TwinStickMovement : MonoBehaviour
{
    // TODO: Move all gun controller code out of this file, rather call this file from a different class to get TwinStick + modify TwinStickMovements internal variables
    [SerializeField] private Animator m_feet_animator;
    [SerializeField] private Transform m_player_transform;
    [SerializeField] public float m_speed_multiplier;
    [SerializeField] public float m_sprint_speed;
    public bool m_is_sprinting = false;
    [SerializeField] public float m_ads_speed;
    public float m_default_speed;

    //[SerializeField] private GunController gc;
    [SerializeField] private TwinStickButtonMap tsm;

    [SerializeField] private Animator m_playermovement_animator;

    [SerializeField] private GameObject m_weapon;

    private string run_animation = "Player_Run Right";



    private Rigidbody2D m_rigid_body;
    private AudioSource m_audio_source;

    [SerializeField] private float m_left_stick_dead_zone;
    [SerializeField] private float m_right_stick_dead_zone;

    [SerializeField] private InventoryController m_inventory_controller; 
    void Awake()
    {
        //gc = GetComponentInChildren<GunController>();
        m_default_speed = m_speed_multiplier;
        m_rigid_body = GetComponent<Rigidbody2D>();
        m_audio_source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {

        //if(m_inventory_controller.inventoryIsShowing())
        //{
        //    m_rigid_body.velocity = Vector2.zero;
        //    return;
        //}

            m_rigid_body.velocity = new Vector2(Mathf.Lerp(0, ControllerInput.LeftStickHorizontal() * m_speed_multiplier, 0.8f),
            Mathf.Lerp(0, ControllerInput.LeftStickVertical() * m_speed_multiplier, 0.8f));

        SetPlayerSpeed();

        bool player_is_walking = (Mathf.Clamp01(new Vector2(ControllerInput.LeftStickHorizontal(), ControllerInput.LeftStickVertical()).magnitude)) > m_left_stick_dead_zone;
        bool player_is_aiming = (Mathf.Clamp01(new Vector2(ControllerInput.RightStickHorizontal(), ControllerInput.RightStickVertical()).magnitude)) > m_right_stick_dead_zone;

        

        if (player_is_aiming)
        {
            float angle = Controller.GetRightAnalogStickAngle();
            m_weapon.transform.localRotation = Quaternion.AngleAxis(Mathf.Ceil(angle) + 90.0f, new Vector3(0, 0, 1));
            Debug.Log("weapon angle: " + angle);

            if(angle <= 180.0f)
            {
                //m_weapon.GetComponentInChildren<GunController>().gameObject.transform.localScale = new Vector3 (1.0f, 1.0f, -1.0f);
                run_animation = "Player_Run Left";
            } else
            {
                //m_weapon.GetComponentInChildren<GunController>().gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                run_animation = "Player_Run Right";
            }
        }

        if (player_is_walking)
        {
            float angle = Controller.GetLeftAnalogStickAngle();
            //feet.transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));

            if (m_audio_source.isPlaying == false)
            {
                m_audio_source.Play();
            }

            m_playermovement_animator.Play(run_animation);
        }

        if (player_is_walking == false)
        {
            m_playermovement_animator.Play("Player_Idle");
        }

    }

    public void SetPlayerSpeed()
    {
        if (m_is_sprinting == true)
        {
            //gc.is_ADS = false;
            m_speed_multiplier = m_sprint_speed;
            m_feet_animator.speed = 1.5f;

        }
        //else if (gc.is_ADS == true)
        //{
        //    m_is_sprinting = false;
        //    m_speed_multiplier = m_ads_speed;
        //    m_feet_animator.speed = 0.5f;
        //}
        else
        {
            m_speed_multiplier = m_default_speed;
            m_feet_animator.speed = 1.0f;
        }
    }
   
}