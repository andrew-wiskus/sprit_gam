using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HealthTextDisplayType
{
    TEXT
}

public class HealthGUI : MonoBehaviour
{
    private Text m_health_text;
    private ShootableObject m_target;
    private float m_max_health;

    [SerializeField] private RectTransform m_inner_health_bar;
    private float m_max_bar_width;

    public void Start()
    {
        m_target = GetComponentInParent<ShootableObject>();
        m_health_text = GetComponentInChildren<Text>();
        m_max_bar_width = m_inner_health_bar.rect.width;
        m_max_health = m_target.GetMaxHealth();

        SetHealthTextDisplayByPercent(1.0f);
    }

    public void SetHealthTextDisplayByPercent(float percent)
    {
        int current_health = Mathf.CeilToInt(m_max_health * percent);
        m_health_text.text = current_health + " / " + Mathf.CeilToInt(m_max_health).ToString();

        float new_rect_width = m_max_bar_width * percent;
        m_inner_health_bar.sizeDelta = new Vector2(new_rect_width, m_inner_health_bar.rect.height);
    }
}
