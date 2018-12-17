using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : GunProperties
{
    [SerializeField] private Animator m_muzzle_flash_animator;

    public override void Reload()
    {
        if (weapon_is_reloading == false)
        {
            StartCoroutine(reload_coroutine());
        }
    }

    public override void FireProjectileCallback()
    {
        if (current_ammo != 0)
        {
            StartCoroutine(load_shell_animation());
        }
    }

    public override void PlayMuzzleFlashAnimation()
    {
        m_muzzle_flash_animator.Play("MuzzleFlash");
    }

    private IEnumerator reload_coroutine()
    {
        weapon_is_reloading = true;

        // START LOAD
        m_weapon_audio.PlayShotgunStartLoad();
        m_weapon_animator.Play("Mossberg_StartLoad");
        yield return new WaitForSeconds(m_weapon_animator.GetCurrentAnimatorStateInfo(0).length);

        // LOAD ONE, FILL CLIP
        while (current_ammo < clip_size)
        {
            yield return load_shell_animation();
            current_ammo++;
            m_gun_gui_controller.SetClipStatus(current_ammo, clip_size);
            yield return new WaitForSeconds(m_weapon_animator.GetCurrentAnimatorStateInfo(0).length);
        }

        m_weapon_audio.PlayShotgunFinishLoad();
        m_weapon_animator.Play("Mossberg_FinishLoad");
        weapon_is_reloading = false;
        is_shooting_projectile = false;
        yield break;
    }

    private IEnumerator load_shell_animation()
    {
        m_weapon_audio.PlayShotgunLoadOne();
        m_weapon_animator.Play("Mossberg_LoadOne");
        yield break;
    }

    private IEnumerator shotgun_pump_animation()
    {
        weapon_is_reloading = true;
        yield return new WaitForSeconds(fire_rate_in_seconds);
        m_weapon_audio.PlayShotgunPump();
        m_weapon_animator.Play("Mossberg_Pump");
        yield return new WaitForSeconds(0.6f);
        weapon_is_reloading = false;
        is_shooting_projectile = false;

        yield break;
    }
}
