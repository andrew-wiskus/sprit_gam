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
        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speedMultiplier, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("Vertical") * speedMultiplier, 0.8f));
    }

    void Update()
    {
        bool controller_is_active = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (controller_is_active)
        {

            float angle = Controller.GetLeftAnalogStickAngle();
            player_transform.rotation = Quaternion.AngleAxis(-angle, new Vector3(0, 0, 1));

            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
            m_animator.Play("Walk");
        }
        else
        {
            m_animator.Play("Idle");
        }
    }


}

public class Controller
{
    public static float GetLeftAnalogStickAngle()
    {

        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
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