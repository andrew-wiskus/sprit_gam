using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageController : MonoBehaviour {

    [SerializeField] float m_damage = 5.0f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy") // TODO: Change `Enemy` to `ShootableObject` because sometimes we may want to shoot world-objects (chest? breakable door?) for a reaction, so we'll need to share the name of this layer
        {
            ShootableObject target = col.gameObject.GetComponent<ShootableObject>(); // ShootableObject will be the base class for anything that is hittable, create a Dragon? It extends `ShootableObject`.
            target.UpdateHealth(-1.0f * m_damage);
            Destroy(gameObject); 
        }

        // TODO: Make projectile destroy on walls, make a `Block Projectiles` layer?;
    }

}
