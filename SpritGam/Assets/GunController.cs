using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunAnimationName
{
    TommyGun_Reload
}

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject m_item_to_shoot;
    [SerializeField] private GameObject m_fire_point;
    [SerializeField] private WeaponAudio m_weapon_audio;
    [SerializeField] private Animator m_weapon_animator;
    [SerializeField] private GunAnimationName m_reload_animation;

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

    public void ReloadWeapon()
    {
        m_weapon_audio.PlayReloadGunSFX();
        m_weapon_animator.Play(m_reload_animation.ToString());
    }

    private void shoot_single_projectile()
    {
        var item = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, transform.rotation);
        m_weapon_audio.PlayFireGunSFX();
    }
}
