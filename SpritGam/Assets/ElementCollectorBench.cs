using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementCollectorBench : AbstractButtonMap {

    [SerializeField] private GameObject m_text_panel;
    private bool is_near_bench = false;

    void Start()
    {
        m_text_panel.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        is_near_bench = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        is_near_bench = false;
    }

    void Update()
    {
        if (is_near_bench)
        {
            m_text_panel.SetActive(true);
        }
        else
        {
            m_text_panel.SetActive(false);
        }

        SpaceshipButtonHandler.isNearElementCollector = is_near_bench;
    }
}
