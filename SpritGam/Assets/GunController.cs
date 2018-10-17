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
    [SerializeField] private int m_clip_size;
    [SerializeField] private float m_reload_time_in_seconds;
    [SerializeField] private GunAnimationName m_reload_animation;
    [SerializeField] private GunGUIController m_gun_gui_controller;
    [SerializeField] private float m_fire_rate_in_seconds;

    private bool m_is_shooting_projectile = false;
    private int m_current_ammo = 0;
    private bool m_weapon_is_reloading = false;

    private void Awake()
    {
        m_current_ammo = m_clip_size;
        m_gun_gui_controller.SetClipStatus(m_current_ammo, m_clip_size);
    }

    void Update()
    {

        if (ControllerInput.RightTrigger() != 0 && m_is_shooting_projectile == false && m_weapon_is_reloading == false)
        {

            Debug.Log("HOLDING DOWN TRIGGER");
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
        while (m_is_shooting_projectile == true)
        {
            if(m_weapon_is_reloading == false)
            {
                shoot_single_projectile();
                yield return new WaitForSeconds(m_fire_rate_in_seconds);
                if(m_weapon_is_reloading == true || m_is_shooting_projectile == false)
                {
                    yield break;
                }
            }
        }

        yield break;
    }

    public void ReloadWeapon()
    {
        if(m_weapon_is_reloading == false)
        {
            StartCoroutine(reload_weapon());
        }
    }

    private IEnumerator reload_weapon()
    {
        m_weapon_is_reloading = true;


        m_weapon_audio.PlayReloadGunSFX();
        m_weapon_animator.Play(m_reload_animation.ToString());

        yield return new WaitForSeconds(m_reload_time_in_seconds);
        m_current_ammo = m_clip_size;
        m_gun_gui_controller.SetClipStatus(m_current_ammo, m_clip_size);
        m_weapon_is_reloading = false;
        m_is_shooting_projectile = false;
        yield break;
    }

    private void shoot_single_projectile()
    {
        if (m_current_ammo != 0)
        {
            var item = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, transform.rotation);
            m_weapon_audio.PlayFireGunSFX();
            m_current_ammo -= 1;
            m_gun_gui_controller.SetClipStatus(m_current_ammo, m_clip_size);
        }
    }
}
