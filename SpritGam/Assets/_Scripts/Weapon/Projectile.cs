using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GunController gunController;
    [SerializeField] int bulletCount;
    private bool bulletIsMoving = true;
    [SerializeField] private float destroyTime;
    [SerializeField] private float m_speed = 1.0f;

    void OnEnable()
    {
        FireBullet();
    }

    public void StopBullet()
    {
        bulletIsMoving = false;
    }

    public void FireBullet()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * m_speed);
    }

    private void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    public void SetSpeed(float speed)
    {
        m_speed = speed;
    }
}