using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeProperties
{
    public Vector2 IncrementVectorMap;
    public float Duration;

    public ShakeProperties(Vector2 shake_increment_vector_map, float shake_duration)
    {
        IncrementVectorMap = shake_increment_vector_map;
        Duration = shake_duration;
    }
}

public class CameraShakeController : MonoBehaviour
{
    [SerializeField] Camera m_test_cam;
    [SerializeField] private CinemachineImpulseSource m_impulse_source;

    public IEnumerator ShakeCameraImpulse()
    {
        Vector3 shakeAmount = new Vector3(1, 1, 1);
        m_impulse_source.GenerateImpulse();

        yield break;
    }

    public void ShakeCamera(ShakeProperties shake_properties)
    {
        Debug.Log(shake_properties);
        StartCoroutine(shake_camera_action(shake_properties));
    }

    private IEnumerator shake_camera_action(ShakeProperties shake_properties)
    {
        var cPos = m_test_cam.transform.position;
        float xInc = shake_properties.IncrementVectorMap.x;
        float yInc = shake_properties.IncrementVectorMap.y;
        float shakeTime = shake_properties.Duration;

        cPos = new Vector3(cPos.x - xInc, cPos.y - yInc, cPos.z);
        m_test_cam.transform.position = cPos;

        yield return new WaitForSeconds(shakeTime);

        cPos = new Vector3(cPos.x + xInc, cPos.y + yInc, cPos.z);
        m_test_cam.transform.position = cPos;
        yield break;
    }

}
