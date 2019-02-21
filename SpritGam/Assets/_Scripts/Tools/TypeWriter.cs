using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriter : MonoBehaviour {

    private int currentPosition = 0;
    [SerializeField] private float letterDelay;
    private string m_text = "";

    private string dialogueOne = "This is a test of dialogue script number 1. See the letters as they spell before you. Read them, and decipher their meaning.  " +
        "             Boobs.                     Cock balls.";

    private string thruster_offline_text = "Captain, our ship's main thrusters are offline. Please restore power to the flux capacitor.";
    [SerializeField] private AudioClip thruster_offline_audio;

    private Text gui_text;
    private AudioSource speech_synthesizer;
    

	void Start () {
        gui_text = GetComponentInChildren<Text>();
        speech_synthesizer = GetComponent<AudioSource>();
        gui_text.text = "";
        currentPosition = 0;

        StartCoroutine(WriteText(thruster_offline_text, thruster_offline_audio));
	}

    public IEnumerator WriteText(string newText, AudioClip newAudio)
    {
        m_text = newText;
        speech_synthesizer.clip = newAudio;
        speech_synthesizer.Play();

        while (true)
        {
            if (currentPosition < m_text.Length)
            {
                gui_text.text += m_text[currentPosition++];
                yield return new WaitForSeconds(letterDelay);
            } else
            {
                Debug.Log("END TEXT");
                yield break;
            }
            
        }
    }
	
}
