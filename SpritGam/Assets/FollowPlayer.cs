using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] private Camera m_camera;
    [SerializeField] private Transform m_player_transform;
    [SerializeField] private PlayerAim m_player_aim;
    [SerializeField] private float m_aim_distance = 3.0f;

    private float magnitude_increment {  get { return m_player_aim.Magnitude > 0.0f ? 0.015f : -0.02f; } }
    private float m_magnitude = 0.0f;
    private float last_x = 0.0f;
    private float last_y = 0.0f;
    private float last_magnitude = 0.0f;
    private float last_angle = 0.0f;
    // Update is called once per frame
    private void Start()
    {
        m_camera.transform.position = get_target_position();
        StartCoroutine(move_camera());
    }

    private IEnumerator move_camera()
    {
        Vector3 current_position = m_camera.transform.position;
        Vector3 target_position = get_target_position();
        m_camera.transform.position = Vector3.Lerp(current_position, target_position, 0.05f);

        yield return new WaitForEndOfFrame();
        yield return move_camera();
    }

    private Vector3 get_target_position()
    {

        float angle = m_player_aim.Magnitude == 0.0f ? last_angle : m_player_aim.Angle;
        last_angle = angle;

        Quaternion quat = Quaternion.AngleAxis(angle, Vector3.back);
        Vector3 new_pos = m_player_transform.position + quat * Vector3.up * (m_aim_distance * m_player_aim.Magnitude);
        return new Vector3(new_pos.x, new_pos.y, -25);
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