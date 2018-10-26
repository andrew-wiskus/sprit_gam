using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private GameObject player;
    private Vector3 camPos;

	// Use this for initialization
	void Start () {
        camPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        camPos = player.transform.position;
        transform.position = new Vector3 (camPos.x, camPos.y, -10);

	}
}
