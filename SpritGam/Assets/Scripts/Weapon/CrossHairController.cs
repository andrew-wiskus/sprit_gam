using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairController : MonoBehaviour {

    [SerializeField] private float m_cross_hair_distance = 0.25f;
    [SerializeField] private float m_horizontal_offset = 0.0f;
    [SerializeField] private float m_ads_distance = 0.5f;

    private float m_verticle_offset = 0.0f;

    public bool StatusOfADS()
    {
        return m_verticle_offset != 0.0f;
    }

    public void SetHorizontalOffset(float offset)
    {
        m_horizontal_offset = offset;
    }

    public void SetDistanceForADS(float distance)
    {
        m_ads_distance = distance;
    }

    public void ToggleADS(bool toggle)
    {
        if(toggle)
        {
            m_verticle_offset = m_ads_distance;
        } else
        {
            m_verticle_offset = 0.0f;
        }
    }

	void Update () {
        transform.localPosition = new Vector3(m_horizontal_offset, m_cross_hair_distance + m_verticle_offset, 0);
	}
}
