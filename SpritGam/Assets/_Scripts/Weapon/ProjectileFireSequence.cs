using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileFireSequence : MonoBehaviour
{
    [SerializeField] public GameObject m_item_to_shoot;
    [SerializeField] public GameObject m_fire_point;

    public abstract void Fire();
}
