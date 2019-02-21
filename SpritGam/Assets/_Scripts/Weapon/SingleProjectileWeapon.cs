using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleProjectileWeapon : GunProperties
{
    [SerializeField] public Animator m_muzzle_flash_animator;

    public override void Reload()
    {
        if (weapon_is_reloading == false)
        {
            StartCoroutine(reload_weapon());
        }
    }

    public override void FireProjectileCallback() { }

    public override void PlayMuzzleFlashAnimation()
    {
        m_muzzle_flash_animator.Play("MuzzleFlash");
    }

    private IEnumerator reload_weapon()
    {
        weapon_is_reloading = true;

        //m_weapon_audio.PlayReloadGunSFX();

        yield return new WaitForSeconds(reload_time_in_seconds);
        current_ammo = clip_size;
        m_gun_gui_controller.SetClipStatus(current_ammo, clip_size);
        weapon_is_reloading = false;
        is_shooting_projectile = false;
        yield break;
    }
}
