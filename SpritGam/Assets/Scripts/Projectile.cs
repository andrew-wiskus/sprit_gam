using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float m_speed = 5f;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * m_speed;
    }

    public void SetSpeed(float speed)
    {
        m_speed = speed;
    }
}
