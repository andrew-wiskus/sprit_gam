using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunProjectileController : ProjectileFireSequence
{
    [SerializeField] private float m_shotgun_spray_angle;

    public override void Fire()
    {
        Quaternion angleWideLeft = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z + m_shotgun_spray_angle)));
        Quaternion angleMidLeft = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z + m_shotgun_spray_angle / 2)));
        Quaternion angleStraight = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z)));
        Quaternion angleMidRight = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z - m_shotgun_spray_angle / 2)));
        Quaternion angleWideRight = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z - m_shotgun_spray_angle)));

        var item = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleWideLeft);
        var item2 = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleMidLeft);
        var item3 = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleStraight);
        var item4 = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleMidRight);
        var item5 = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleWideRight);
    }
}

