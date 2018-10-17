using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunAnimationName
{
    TommyGun_Reload,
    DesertEagle_Reload
}

public enum GunFireStyle
{
    AUTOMATIC,
    SEMI_AUTOMATIC,
    BURST_SEMIAUTO,
    BURST_AUTOMATIC
}

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject m_item_to_shoot;
    [SerializeField] private GameObject m_fire_point;
    [SerializeField] private WeaponAudio m_weapon_audio;
    [SerializeField] private Animator m_weapon_animator;
    [SerializeField] private int m_clip_size = 60;
    [SerializeField] private float m_reload_time_in_seconds = 1.75f;
    [SerializeField] private GunAnimationName m_reload_animation;
    [SerializeField] private GunGUIController m_gun_gui_controller;
    [SerializeField] private float m_fire_rate_in_seconds = 0.15f;
    [SerializeField] private bool m_should_auto_reload = false;
    [SerializeField] private GunFireStyle m_fire_style;
    [SerializeField] private float m_burst_speed = 0.05f;
    [SerializeField] private int m_burst_count = 3;
    [SerializeField] private float m_firerate_inbetween_bursts_in_seconds = 0.15f;


    private bool m_is_shooting_projectile = false;
    private int m_current_ammo = 0;
    private bool m_weapon_is_reloading = false;
    private bool m_trigger_was_toggled = true;

    public void SwitchFireMode(GunFireStyle style)
    {
        m_fire_style = style;
    }
    private void Awake()
    {
        m_current_ammo = m_clip_size;
        m_gun_gui_controller.SetClipStatus(m_current_ammo, m_clip_size);
        StartCoroutine(start_trigger_listener());
    }

    private IEnumerator start_trigger_listener()
    {


        while (ControllerInput.RightTrigger() <= 0.2)
        {
            yield return new WaitForEndOfFrame();
        }


        yield return pull_gun_trigger();

        if (ControllerInput.RightTrigger() >= 0.2)
        {
            yield return new WaitForEndOfFrame();
        }
        else
        {
            m_trigger_was_toggled = true;
        }


        yield return start_trigger_listener();
        yield break;
    }

    private IEnumerator pull_gun_trigger()
    {
        if (ControllerInput.RightTrigger() <= 0.2)
        {
            yield break;
        }


        if (m_weapon_is_reloading == false)
        {
            switch (m_fire_style)
            {

                case GunFireStyle.AUTOMATIC:
                    shoot_single_projectile();
                    yield return new WaitForSeconds(m_fire_rate_in_seconds);
                    yield return pull_gun_trigger();

                    yield break;

                case GunFireStyle.BURST_SEMIAUTO:
                    if (m_trigger_was_toggled)
                    {

                        for (int i = 0; i < m_burst_count; i++)
                        {
                            shoot_single_projectile();
                            yield return new WaitForSeconds(m_burst_speed);
                        }

                        yield return new WaitForSeconds(m_firerate_inbetween_bursts_in_seconds);
                        m_trigger_was_toggled = false;
                    }

                    break;

                case GunFireStyle.BURST_AUTOMATIC:
                    if (m_trigger_was_toggled)
                    {

                        for (int i = 0; i < m_burst_count; i++)
                        {
                            shoot_single_projectile();
                            yield return new WaitForSeconds(m_burst_speed);
                        }

                        yield return new WaitForSeconds(m_firerate_inbetween_bursts_in_seconds);
                       
                        yield return pull_gun_trigger();
                    }

                    break;

                case GunFireStyle.SEMI_AUTOMATIC:
                    if (m_trigger_was_toggled)
                    {
                        shoot_single_projectile();
                        m_trigger_was_toggled = false;
                    }

                    yield break;
            }
        }

        yield break;
    }

    public void ReloadWeapon()
    {
        if (m_weapon_is_reloading == false)
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
            if (m_current_ammo == 0 && m_should_auto_reload)
            {
                StartCoroutine(reload_weapon());
            }
        }
    }
}
