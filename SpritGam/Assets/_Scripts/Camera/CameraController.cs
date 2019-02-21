using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour {

    [SerializeField] private GameObject player;
    [SerializeField] private Transform m_camera_transform;

    
	void Update () {

        Vector3 new_position = player.transform.position;
        m_camera_transform.position = new Vector3 (new_position.x, new_position.y, -10);
	}
}
