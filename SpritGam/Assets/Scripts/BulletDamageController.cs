using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageController : MonoBehaviour {

    [SerializeField] float m_damage = 5.0f;
    [SerializeField] GameObject bloodSplatter;
    [SerializeField] GameObject headExplosion;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy") // TODO: Change `Enemy` to `ShootableObject` because sometimes we may want to shoot world-objects (chest? breakable door?) for a reaction, so we'll need to share the name of this layer
        {
            gameObject.GetComponent<Projectile>().StopBullet();
            
            Debug.Log("Bullet speed:" + gameObject.GetComponent<Rigidbody2D>().velocity);
            ShootableObject target = col.gameObject.GetComponent<ShootableObject>(); // ShootableObject will be the base class for anything that is hittable, create a Dragon? It extends `ShootableObject`.
            target.UpdateHealth(-1.0f * m_damage);
            if(target.m_current_health <= 0.0f)
            {
                StartCoroutine(HeadExplode());
            } else
            {
                StartCoroutine(BloodSplatter());
            }
            
             
        }

        // TODO: Make projectile destroy on walls, make a `Block Projectiles` layer?;
    }

    private IEnumerator BloodSplatter()
    {
        bloodSplatter.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        yield break;
    }

    private IEnumerator HeadExplode()
    {
        headExplosion.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        yield break;
    }

}
