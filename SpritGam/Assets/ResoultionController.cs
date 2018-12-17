using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoultionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // (width, height, true)
        //Screen.SetResolution(2000, 1200, true);
        //Screen.SetResolution(720, 1280, true);

        Debug.Log("Screen height: " + Screen.height);
        Debug.Log("Screen current resolution: " + Screen.currentResolution);
        Debug.Log("Screen supported resolutions: " + Screen.resolutions);
        Debug.Log("Screen DPI: " + Screen.dpi);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
