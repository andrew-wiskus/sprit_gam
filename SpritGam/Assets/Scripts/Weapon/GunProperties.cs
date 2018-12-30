using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class GunProperties : MonoBehaviour
{
    [SerializeField] public ProjectileFireSequence m_projectile_fire_sequence;
    // TODO: [SerializeField] public WeaponAudio m_weapon_audio;
    [SerializeField] public Animator m_weapon_animator;
    [SerializeField] public GunGUIController m_gun_gui_controller;
    [SerializeField] public VibrationController m_vibration_controller;
    // TODO: [SerializeField] public CameraShakeController m_camera_shake_controller;

    [SerializeField] public float fire_rate_in_seconds = 0.25f;
    [SerializeField] public bool should_auto_reload = true;
    [SerializeField] public int clip_size = 6;
    [SerializeField] public float on_fire_vibration_length;
    [SerializeField] public float on_fire_vibration_strength;
    [SerializeField] public float burst_speed;
    [SerializeField] public float burst_fire_rate;
    [SerializeField] public int burst_count;
    [SerializeField] public GunFireStyle[] fire_styles;
    [SerializeField] private GameObject weapon_attachment;
    [SerializeField] public float reload_time_in_seconds = 1.0f;
    [SerializeField] public Vector2 on_fire_shake_distance;
    [SerializeField] public float on_fire_shake_duration;
    [SerializeField] public string weapon_name;

    [System.NonSerialized] public int current_fire_style_index;
    [System.NonSerialized] public bool is_shooting_projectile = false;
    [System.NonSerialized] public int current_ammo = 30;
    [System.NonSerialized] public bool weapon_is_reloading = false;

    public void OnEnable()
    {
        m_gun_gui_controller.SetClipStatus(clip_size, clip_size);
        m_gun_gui_controller.SetFireMode(fire_styles[0].ToString());
        m_gun_gui_controller.SetCurrentWeapon(weapon_name);
        current_ammo = clip_size;
    }

    public void FireWeapon()
    {
        if (current_ammo != 0)
        {
            current_ammo -= 1;

            m_projectile_fire_sequence.Fire();
            // TODO: m_weapon_audio.PlayFireGunSFX(); 
            m_vibration_controller.Vibrate(on_fire_vibration_length, on_fire_vibration_strength);
            // TODO: m_camera_shake_controller.ShakeCamera(new ShakeProperties(on_fire_shake_distance, on_fire_shake_duration));
            m_gun_gui_controller.SetClipStatus(current_ammo, clip_size);

            PlayMuzzleFlashAnimation();
            FireProjectileCallback();

            if (current_ammo == 0 && should_auto_reload)
            {
                Reload();
            }
        }
        else
        {
            // TODO: m_weapon_audio.PlayDryFireSFX();
        }
    }

    public void ToggleFireStyle()
    {
        current_fire_style_index += 1;
        if (current_fire_style_index >= fire_styles.Length)
        {
            current_fire_style_index = 0;
        }

        string fire_mode = fire_styles[current_fire_style_index].ToString();
        m_gun_gui_controller.SetFireMode(fire_mode);
    }

    public void ToggleAttachment()
    {
        if(weapon_attachment == null)
        {
            return;
        }

        if (weapon_attachment.activeSelf == false)
        {
            weapon_attachment.SetActive(true);
        }
        else
        {
            weapon_attachment.SetActive(false);
        }
    }

    public abstract void Reload();
    public abstract void FireProjectileCallback();
    public abstract void PlayMuzzleFlashAnimation();
    // TODO: public abstract void PlayWeaponSFX();
    // TODO: public abstract void PlayDryFireSFX();
}

