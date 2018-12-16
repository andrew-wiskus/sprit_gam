using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoultionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // (width, height, true)
        Screen.SetResolution(2000, 1200, true);
        Debug.Log("set res");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
