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
        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("LeftHorizontal") * speedMultiplier, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("LeftVertical") * speedMultiplier, 0.8f));
    }

    void Update()
    {
        bool player_is_walking = Input.GetAxis("LeftHorizontal") != 0 || Input.GetAxis("LeftVertical") != 0;
        bool player_is_aiming = Input.GetAxis("RightHorizontal") != 0 || Input.GetAxis("RightVertical") != 0;

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
    }


}

public class Controller
{
    public static float GetRightAnalogStickAngle()
    {

        float y = Input.GetAxis("RightVertical");
        float x = Input.GetAxis("RightHorizontal");
        float angle = Mathf.Atan2(y, x) - Mathf.PI / 2;
        angle = Mathf.Rad2Deg * angle;

        if (angle < 0)
        {
            angle = angle * -1.0f;
        }
        else if (angle > 0)
        {
            angle = (90.0f - angle) + 270.0f;
        }

        return angle;
    }
}