using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] private Camera m_camera;
    [SerializeField] private Transform m_player_transform;
    [SerializeField] private PlayerAim m_player_aim;
    [SerializeField] private float m_aim_distance = 5.0f;
    // Update is called once per frame
    void FixedUpdate() {
        //m_camera.transform.position = Pixel.GetClampedPosition(m_player_transform.position, -25);
        Debug.Log(m_player_aim.Magnitude);
        Debug.Log(m_player_aim.Angle);
        m_camera.transform.position = player_position();
    }

    private Vector3 player_position()
    {
        float x_multiplier = 0.0f;
        float y_multiplier = 0.0f;
        float angle = Mathf.Max(m_player_aim.Angle, 0.01f);

        if (m_player_aim.Angle <= 90.0f)
        {
          x_multiplier = 0.0f + (angle / 90.0f);
          y_multiplier = 1.0f - (angle / 90.0f);

        } else if (m_player_aim.Angle <= 180.0f)
        {
            angle = angle - 90.0f;

            x_multiplier = 1.0f - (angle / 90.0f);
            y_multiplier = 0.0f - (angle / 90.0f);
        } else if (m_player_aim.Angle <= 270.0f)
        {
            angle = angle - 180.0f;

            x_multiplier = 0.0f - (angle / 90.0f);
             y_multiplier = -1.0f + (angle / 90.0f);
        } else
        {
            angle = angle - 270.0f;
            x_multiplier = -1.0f + (angle / 90.0f);
            y_multiplier = 0.0f + (angle / 90.0f);
        }

        float x = m_player_transform.position.x + (m_aim_distance * m_player_aim.Magnitude * x_multiplier);
        float y = m_player_transform.position.y + (m_aim_distance * m_player_aim.Magnitude * y_multiplier);
        return new Vector3(x , y, -25);
    }
}


public static class Pixel {
    public static Vector3 GetClampedPosition(Vector2 position, int z_position)
    {
        // todo: this works but only move the camera on intervals of an int.. need to find exact value for pixel of screen width
        Vector3 clamped_position = new Vector3((int)position.x, (int)position.y, z_position);
        return clamped_position;
    }
 }