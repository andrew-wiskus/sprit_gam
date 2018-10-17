using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour {

    [SerializeField] public AudioSource m_audioSource;

    [SerializeField] private AudioClip tommyGun_Reload_audio;
    [SerializeField] private AudioClip tommyGun_Fire_audio;


    // Use this for initialization
    void Awake () {
        
    }
	
    public void reloadTommyGun()
    {
        m_audioSource.clip = tommyGun_Reload_audio;
        m_audioSource.Play();
    }
    
    public void fireTommyGun()
    {
        m_audioSource.clip = tommyGun_Fire_audio;
        m_audioSource.Play();

    }

	// Update is called once per frame
	void Update () {
        

    }
}
