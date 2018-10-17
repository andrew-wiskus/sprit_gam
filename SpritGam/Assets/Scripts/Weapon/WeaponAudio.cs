using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAudio : MonoBehaviour {

    [SerializeField] private AudioClip tommyGun_Reload_audio;
    [SerializeField] public AudioSource m_audioSource;


    // Use this for initialization
    void Awake () {
        
    }
	
    public void reloadTommyGun()
    {
        m_audioSource.clip = tommyGun_Reload_audio;
        m_audioSource.Play();
        
    }

	// Update is called once per frame
	void Update () {
        

    }
}
