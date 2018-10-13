using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private AudioSource audioSrc;
    public Animator m_animator;

    [SerializeField]
    private Transform player_transform;

    [SerializeField]
    private float speedMultiplier;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSrc = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Mathf.Lerp(0, ControllerInput.LeftStickHorizontal() * speedMultiplier, 0.8f),
            Mathf.Lerp(0, ControllerInput.LeftStickVertical() * speedMultiplier, 0.8f));
    }

    void Update()
    {
        bool player_is_walking = ControllerInput.LeftStickHorizontal() != 0 || ControllerInput.LeftStickVertical() != 0;
        bool player_is_aiming = ControllerInput.RightStickHorizontal() != 0 || ControllerInput.RightStickVertical() != 0;
        bool right_trigger_active = ControllerInput.RightTrigger() != 0;

        if (player_is_aiming)
        {
            float angle = Controller.GetRightAnalogStickAngle();
            player_transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
        }

        if (player_is_walking)
        {
            if (audioSrc.isPlaying == false)
            {
                audioSrc.Play();
            }

            m_animator.Play("Walk");
        }

        if (player_is_aiming == false && player_is_walking == false)
        {
            m_animator.Play("Idle");
        }

        if(right_trigger_active)
        {
            Debug.Log(ControllerInput.RightTrigger());
        }
    }

}