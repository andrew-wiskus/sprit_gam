using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleProjectileController : ProjectileFireSequence
{
    public override void Fire()
    {
        GameObject item = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, transform.rotation);
      }
}