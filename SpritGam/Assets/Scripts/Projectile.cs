using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

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

    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
