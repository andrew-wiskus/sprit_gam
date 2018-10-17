using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour {

    [SerializeField] private AudioClip tommyGun_Reload_audio;
    [SerializeField] public AudioSource m_reloadSound;

    [SerializeField] private AudioClip tommyGun_Fire_audio;
    [SerializeField] public AudioSource m_fireSound;


    // Use this for initialization
    void Awake () {
        
    }
	
    public void reloadTommyGun()
    {
        m_reloadSound.clip = tommyGun_Reload_audio;
        m_reloadSound.Play();
    }
    
    public void fireTommyGun()
    {
        m_fireSound.clip = tommyGun_Fire_audio;
        m_fireSound.Play();

    }

	// Update is called once per frame
	void Update () {
        

    }
}
