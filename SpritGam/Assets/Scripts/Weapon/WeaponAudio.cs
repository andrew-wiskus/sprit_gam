using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour {

    [SerializeField] private AudioSource m_audio_source;
    [SerializeField] private AudioClip m_reload_audioclip;
    [SerializeField] private AudioClip m_fire_audioclip;

    [SerializeField] private AudioClip m_shotgun_startLoad;
    [SerializeField] private AudioClip m_shotgun_loadOne;
    [SerializeField] private AudioClip m_shotgun_finishLoad;
    [SerializeField] private AudioClip m_shotgun_pump;

    [SerializeField] private AudioClip m_dry_fire_audioclip;

    public void PlayReloadGunSFX()
    {
        m_audio_source.clip = m_reload_audioclip;
        m_audio_source.Play();
    }
    
    public void PlayFireGunSFX()
    {
        m_audio_source.clip = m_fire_audioclip;
        m_audio_source.Play();
    }

    public void PlayDryFireSFX()
    {
        m_audio_source.clip = m_dry_fire_audioclip;
        m_audio_source.Play();
    }

    // SHOTGUN
    public void PlayShotgunStartLoad()
    {
        m_audio_source.clip = m_shotgun_startLoad;
        m_audio_source.Play();
    }
    public void PlayShotgunLoadOne()
    {
        m_audio_source.clip = m_shotgun_loadOne;
        m_audio_source.Play();
    }
    public void PlayShotgunFinishLoad()
    {
        m_audio_source.clip = m_shotgun_finishLoad;
        m_audio_source.Play();
    }
    public void PlayShotgunPump()
    {
        m_audio_source.clip = m_shotgun_pump;
        m_audio_source.Play();
    }

}
