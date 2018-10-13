using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject m_item_to_shoot;

    private bool m_is_shooting_projectile = false;

    void Update()
    {

        if (ControllerInput.RightTrigger() != 0 && m_is_shooting_projectile == false)
        {
            m_is_shooting_projectile = true;
            StartCoroutine(pull_gun_trigger());
        }

        if (ControllerInput.RightTrigger() == 0)
        {
            m_is_shooting_projectile = false;
        }
    }

    private IEnumerator pull_gun_trigger()
    {
        while(m_is_shooting_projectile == true)
        {
            Debug.Log("FIRE!!");
            shoot_single_projectile();
            yield return new WaitForSeconds(0.25f);
        }

        yield break;
    }

    private void shoot_single_projectile()
    {
        var item = (GameObject)Instantiate(m_item_to_shoot, transform.position, transform.rotation);
    }
}
