using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] GunController gunController;
    [SerializeField] int bulletCount;
    private bool bulletIsMoving = true;

    public void StopBullet()
    {
        bulletIsMoving = false;
    }

    void Update()
    {
        if (bulletIsMoving == true)
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }
        
    }
}
