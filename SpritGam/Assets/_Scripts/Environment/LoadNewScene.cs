using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNewScene : MonoBehaviour {

    [SerializeField] string m_scene_to_load;

	// Use this for initialization
	void Start () {
        //m_scene_to_load = "Floor_2";
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(m_scene_to_load);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
