using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetEffect
{
    HEALTH
}

public class ShootableObject : MonoBehaviour // TODO: We have to style this into an inheritable class, anything that can be hit by any player-made collideable should probably extend from this.
{ 

    [SerializeField] float m_max_health;
    public float m_current_health;

    private HealthGUI m_health_gui;

    void Start()
    {
        m_health_gui = GetComponentInChildren<HealthGUI>(); // TODO: There is a way to assert these relationships using decorators to the class
        m_current_health = m_max_health;
    }

    private void destroy_target()
    {
        //play animation here:
        Destroy(gameObject);
    }

    public void UpdateHealth(float added_health_difference)
    {

        m_current_health += added_health_difference;
        m_health_gui.SetHealthTextDisplayByPercent(m_current_health / m_max_health);

        if(m_current_health <= 0.0f)
        {
            destroy_target();
        }
    }

    public float GetMaxHealth()
    {
        return m_max_health;
    }
}
