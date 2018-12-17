using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private CameraShakeController m_camera_shake_controller;

    public CameraShakeController CameraShakeController { get { return m_camera_shake_controller; } }

}
