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

    [SerializeField] GunController gunController;
    [SerializeField] int bulletCount;
    private bool bulletIsMoving = true;
    [SerializeField] private float destroyTime;
    
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
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
    }

        Destroy(gameObject, destroyTime);