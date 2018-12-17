using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float m_speed = 5f;

    [SerializeField] GunController gunController;
    [SerializeField] int bulletCount;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }

    public void SetSpeed(float speed)
    {
        m_speed = speed;
    }
}

        transform.position += transform.up * Time.deltaTime * m_speed;