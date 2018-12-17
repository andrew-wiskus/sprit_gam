using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualWeapon : GunProperties
{
    public void ReloadDualWeapon()
    {
        if (weapon_is_reloading == false)
        {
            StartCoroutine(reload_dual());
        }
    }


    private IEnumerator reload_dual()
    {
        weapon_is_reloading = true;

        m_weapon_audio.PlayReloadGunSFX();

        yield return new WaitForSeconds(reload_time_in_seconds);
        current_ammo = clip_size;
        m_gun_gui_controller.SetClipStatus(current_ammo, clip_size);
        weapon_is_reloading = false;
        is_shooting_projectile = false;


        yield break;
    }

    public override void Reload()
    {
        ReloadDualWeapon();
    }

    public override void FireProjectileCallback()
    {
    }

    public override void PlayMuzzleFlashAnimation()
    {
    }
}