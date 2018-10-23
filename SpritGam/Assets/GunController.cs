using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunAnimationName
{
    TommyGun_Reload,
    DesertEagle_Reload,
    Mossberg_Reload,
    Mac11_Reload,
    Mac11Dual_Reload,
    Vape_Reload
}

public enum GunFireStyle
{
    AUTOMATIC,
    SEMI_AUTOMATIC,
    BURST_SEMIAUTOMATIC,
    BURST_AUTOMATIC,
    SHOTGUN_PUMP,
    SHOTGUN_SEMIAUTO,
    VAPE_HIT
}

public enum WeaponStance
{
    SINGLE_HAND,
    DOUBLE_HAND,
    DUAL_WIELD,
    MELEE,
    NONE
}

public class GunController : MonoBehaviour
{
    [SerializeField] public WeaponStance weaponType;
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
  
    [SerializeField] private float m_burst_speed = 0.05f;
    [SerializeField] private int m_burst_count = 3;
    [SerializeField] private float m_firerate_inbetween_bursts_in_seconds = 0.15f;
    [SerializeField] private GunFireStyle[] m_fire_styles = new GunFireStyle[] { GunFireStyle.AUTOMATIC, GunFireStyle.SEMI_AUTOMATIC, GunFireStyle.BURST_SEMIAUTOMATIC, GunFireStyle.BURST_AUTOMATIC };

    [SerializeField] private GameObject crosshair;


    private bool m_is_shooting_projectile = false;
    private int m_current_ammo = 0;
    private bool m_weapon_is_reloading = false;
    private bool m_trigger_was_toggled = true;
    private int m_fire_style_index = 0;

    public bool m_is_shotgun;
    public int m_shotgun_spray_angle;

    public bool m_is_dual;
    public bool m_is_vape;

    


    private void OnEnable()
    {
        m_current_ammo = m_clip_size;
        init_gui();
        StartCoroutine(start_trigger_listener());
    }
    
    

    private void init_gui()
    {
        m_gun_gui_controller.SetClipStatus(m_current_ammo, m_clip_size);
        m_gun_gui_controller.SetFireMode(m_fire_styles[m_fire_style_index].ToString());
    }

    public void ToggleFireStyle()
    {
        m_fire_style_index += 1;
        if (m_fire_style_index >= m_fire_styles.Length)
        {
            m_fire_style_index = 0;
        }

        m_gun_gui_controller.SetFireMode(m_fire_styles[m_fire_style_index].ToString());
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

        if (m_current_ammo == 0)
        {
            m_weapon_audio.PlayDryFireSFX();
            yield break;
        }


        if (m_weapon_is_reloading == false)
        {

            switch (m_fire_styles[m_fire_style_index])
            {

                case GunFireStyle.AUTOMATIC:
                    shoot_single_projectile();
                    yield return new WaitForSeconds(m_fire_rate_in_seconds);
                    yield return pull_gun_trigger();

                    yield break;

                case GunFireStyle.BURST_SEMIAUTOMATIC:
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

                    yield break;

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

                    yield break;

                case GunFireStyle.SEMI_AUTOMATIC:
                    if (m_trigger_was_toggled)
                    {
                        shoot_single_projectile();
                        m_trigger_was_toggled = false;
                    }

                    yield break;

                // PAT
                case GunFireStyle.SHOTGUN_PUMP:
                    if (m_trigger_was_toggled)
                    {
                        shoot_shotgun_pellets();
                        m_trigger_was_toggled = false;
                        if (m_current_ammo == 0)
                        {
                            yield break;
                        }
                        StartCoroutine(shotgun_pump());

                        
                    }

                    yield break;

                case GunFireStyle.SHOTGUN_SEMIAUTO:
                    if (m_trigger_was_toggled)
                    {
                        shoot_shotgun_pellets();
                        m_trigger_was_toggled = false;
                    }

                    yield break;

                case GunFireStyle.VAPE_HIT:
                    if (m_trigger_was_toggled)
                    {
                        StartCoroutine(hitVape());
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

    public void ReloadDualWeapon()
    {
        if (m_weapon_is_reloading == false)
        {
            StartCoroutine(reload_dual());
        }
    }

    // PAT
    public void ReloadShotgun()
    {
        if (m_weapon_is_reloading == false)
        {
            StartCoroutine(reload_shotgun());
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

    private IEnumerator reload_dual()
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

    private IEnumerator hitVape()
    {
        m_weapon_animator.Play("Vape_Hit");
        yield return new WaitForSeconds(0.5f);
        m_weapon_audio.HitVape();
        yield return new WaitForSeconds(m_reload_time_in_seconds);
        m_weapon_animator.Play("Vape_Blow");
        m_weapon_audio.BlowVape();
        yield break;
    }

    // PAT
    private IEnumerator reload_shotgun()
    {
        m_weapon_is_reloading = true;

        // START LOAD
        m_weapon_audio.PlayShotgunStartLoad();
        m_weapon_animator.Play("Mossberg_StartLoad");
        yield return new WaitForSeconds(m_weapon_animator.GetCurrentAnimatorStateInfo(0).length);

        // LOAD ONE, FILL CLIP
        while (m_current_ammo < m_clip_size)
        {
              StartCoroutine(load_shell());
              m_current_ammo++;
            m_gun_gui_controller.SetClipStatus(m_current_ammo, m_clip_size);
            yield return new WaitForSeconds(m_weapon_animator.GetCurrentAnimatorStateInfo(0).length);
        }
        
        // FINISH LOAD
        m_weapon_audio.PlayShotgunFinishLoad();
        m_weapon_animator.Play("Mossberg_FinishLoad");
        m_weapon_is_reloading = false;
        m_is_shooting_projectile = false;
        yield break;
    }

    private IEnumerator load_shell()
    {
        m_weapon_audio.PlayShotgunLoadOne();
        m_weapon_animator.Play("Mossberg_LoadOne");
        yield break;
    }


    private IEnumerator shotgun_pump()
    {
        m_weapon_is_reloading = true;
        yield return new WaitForSeconds(m_fire_rate_in_seconds);
        m_weapon_audio.PlayShotgunPump();
        m_weapon_animator.Play("Mossberg_Pump");
        yield return new WaitForSeconds(0.6f);
        m_weapon_is_reloading = false;
        m_is_shooting_projectile = false;
        
        yield break;
    }


    private void shoot_single_projectile()
    {
        if (m_current_ammo != 0)
        {
            var item = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, transform.rotation);
            
            m_current_ammo -= 1;
            m_gun_gui_controller.SetClipStatus(m_current_ammo, m_clip_size);
            m_weapon_audio.PlayFireGunSFX();
            if (m_current_ammo == 0 && m_should_auto_reload)
            {
                StartCoroutine(reload_weapon());
            }
        }

    }
    

    private void shoot_shotgun_pellets()
    {
        Quaternion angleWideLeft = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z + m_shotgun_spray_angle)));
        Quaternion angleMidLeft = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z + m_shotgun_spray_angle / 2)));
        Quaternion angleStraight = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z)));
        Quaternion angleMidRight = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z - m_shotgun_spray_angle / 2)));
        Quaternion angleWideRight = transform.rotation * (Quaternion.Euler(new Vector3(0, 0, transform.rotation.z - m_shotgun_spray_angle)));

        if (m_current_ammo != 0)
        {
            var item = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleWideLeft);
            var item2 = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleMidLeft);
            var item3 = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleStraight);
            var item4 = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleMidRight);
            var item5 = (GameObject)Instantiate(m_item_to_shoot, m_fire_point.transform.position, angleWideRight);
            m_weapon_audio.PlayFireGunSFX();
            m_current_ammo -= 1;
            m_gun_gui_controller.SetClipStatus(m_current_ammo, m_clip_size);
            

            if (m_current_ammo == 0 && m_should_auto_reload)
            {
                StartCoroutine(reload_shotgun());
            }
        }


    }

    void Update()
    {
        if (m_weapon_is_reloading == true)
        {
            crosshair.SetActive(false);
        }
        else
        {
            crosshair.SetActive(true);
        }
    }

}
