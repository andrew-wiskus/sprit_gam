using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MinerDTR : MonoBehaviour
{

    [SerializeField] private Text m_output_text;
    [SerializeField] private Text m_capacity_text;
    [SerializeField] private Text m_speed_text;
    [SerializeField] private Text m_element_text;
    [SerializeField] private Text m_location_text;
    [SerializeField] private Text m_fuel_text;

    [SerializeField] private float m_output_per_sec;
    [SerializeField] private float m_current_capacity;
    [SerializeField] private float m_max_capacity;
    [SerializeField] private float m_meters_per_sec;
    [SerializeField] private float m_current_distance;
    [SerializeField] private float m_destination_distance;
    [SerializeField] private float m_fuel_per_trip;

    private long last_tick = 0;
    [SerializeField] private float m_ticks_per_second;
    private float tick_interval { get { return 1000 / m_ticks_per_second; } }

    private void Start()
    {
        // init_values();

        m_output_text.text = "Output: " + m_output_per_sec + " / s";
        m_capacity_text.text = "Capacity: " + m_current_capacity + " / " + m_max_capacity;
        m_speed_text.text = "Speed: " + m_meters_per_sec + "m / s";
        m_element_text.text = "Mining: " + "Hydrogen";
        m_location_text.text = "Location: " + m_current_distance + " / " + m_destination_distance;
    }

    private bool is_mining = false;
    private bool is_returning_to_ship = false;

    public void FixedUpdate()
    {
        if (on_tick())
        {

            if (is_mining == true)
            {
                float output_per_tick = m_output_per_sec / m_ticks_per_second;

                float capacity = m_current_capacity + output_per_tick;

                if (capacity >= m_max_capacity)
                {
                    is_mining = false;
                    is_returning_to_ship = true;
                    m_current_capacity = m_max_capacity;

                } else
                {
                    m_current_capacity = m_current_capacity + output_per_tick;
                }

            }
            else
            {
                float meters_per_tick = m_meters_per_sec / m_ticks_per_second;

                if (is_returning_to_ship == true)
                {
                    float current_distance = m_current_distance - meters_per_tick;

                    if (current_distance <= 0)
                    {
                        m_current_capacity = 0;
                        is_returning_to_ship = false;

                        return;
                    }
                    else
                    {
                        m_current_distance = m_current_distance - meters_per_tick;
                    }

                }
                else
                {
                    float distance = m_current_distance + meters_per_tick;

                    if (distance >= m_destination_distance)
                    {
                        is_mining = true;
                        m_current_distance = m_destination_distance;

                    }
                    else
                    {
                        m_current_distance = m_current_distance + meters_per_tick;
                    }
                }
            }

            update_interface();
        }
    }

    private void update_interface()
    {
        m_capacity_text.text = "Capacity: " + (int)m_current_capacity + " / " + m_max_capacity;
        m_location_text.text = "Location: " + (int)m_current_distance + " / " + m_destination_distance;
    }

    private bool on_tick()
    {
        long current_tick = GameTime.CurrentTimeUnix;
        if (current_tick >= last_tick + tick_interval)
        {
            last_tick = current_tick;
            return true;
        }

        return false;
    }
}
