using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour {

    [SerializeField] private AudioSource m_audio_source;
    [SerializeField] private AudioClip m_reload_audioclip;
    [SerializeField] private AudioClip m_fire_audioclip;

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
}
