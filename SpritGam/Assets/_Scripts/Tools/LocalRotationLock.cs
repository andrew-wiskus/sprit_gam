using UnityEngine;

public class LocalRotationLock : MonoBehaviour {

    private Quaternion init_rotation;
    [SerializeField] private bool m_lock_rotation;

    void Start()
    {
        init_rotation = transform.rotation;
    }
	
	void LateUpdate () {
        if (m_lock_rotation)
        {
            transform.rotation = init_rotation;
        }
	}
}
