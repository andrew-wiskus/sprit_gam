using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    [HideInInspector] public AudioSource playerAudio;

    [SerializeField] private AudioClip footstep_default;
    [SerializeField] private float m_footstep_volume_default;

    [HideInInspector] public AnimationEvent play_footstep;


    
	void Start () {
        playerAudio = GameObject.Find("Player").GetComponent<AudioSource>();
	}

    public void PlayFoostep()
    {
        playerAudio.clip = footstep_default;
        playerAudio.volume = m_footstep_volume_default;
        playerAudio.Play();
    }

}
