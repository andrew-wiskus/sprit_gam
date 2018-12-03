using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] GunController gunController;
    [SerializeField] int bulletCount;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }
}
