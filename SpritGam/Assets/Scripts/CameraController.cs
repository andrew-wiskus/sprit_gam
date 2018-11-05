using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour {

    [SerializeField] private GameObject player;
    private Vector3 camPos;
    private CinemachineImpulseSource impulse;
    

	// Use this for initialization
	void Start () {
        camPos = transform.position;
        
	}

    public IEnumerator CamFollow()
    {
        camPos = player.transform.position;
        transform.position = new Vector3(camPos.x, camPos.y, -10);
        yield break;
    }
    
	
	// Update is called once per frame
	void Update () {

        camPos = player.transform.position;
        transform.position = new Vector3 (camPos.x, camPos.y, -10);

	}
}
