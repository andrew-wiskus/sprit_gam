using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MinerDroid : MonoBehaviour
{
    [SerializeField] private Text m_mining_speed_text;
    [SerializeField] private Text m_capacity_text;
    [SerializeField] private Text m_speed_text;
    [SerializeField] private Text m_element_text;
    [SerializeField] private Text m_location_text;
    [SerializeField] private Text m_fuel_text;

    [SerializeField] private float m_mining_per_sec;
    [SerializeField] private float m_max_capacity;
    [SerializeField] private float m_meters_per_sec;
    [SerializeField] private float m_destination_distance;
    [SerializeField] private float m_fuel_per_trip;
    [SerializeField] private float m_delivery_per_sec;

    [SerializeField] private ElementType m_element;
    public ElementType element {  get { return m_element; } }

    private float m_current_distance;
    private float m_current_capacity;

    private float last_tick = 0;
    [SerializeField] private float m_ticks_per_second;
    private float tick_interval { get { return 1000 / m_ticks_per_second; } }

    private void Start()
    {
        m_mining_speed_text.text = "Mining Speed: " + m_mining_per_sec + " / s";
        m_capacity_text.text = "Capacity: " + m_current_capacity + " / " + m_max_capacity;
        m_speed_text.text = "Speed: " + m_meters_per_sec + "m / s";
        m_element_text.text = "Mining: " + m_element.ToString();
        m_location_text.text = "Location: " + m_current_distance + " / " + m_destination_distance;
        start_time = GameTime.CurrentTimeUnix;
        start_inventory = MiningInventory.CurrentSupply(m_element);
    }

    private bool isMining = false;
    private bool isReturningToShip = false;
    private bool isDocked = false;

    public void FixedUpdate()
    {
        update_interface();

        if (on_tick())
        {

            if (isDocked)
            {
                float delivery_per_tick = m_delivery_per_sec / m_ticks_per_second;

                if (m_current_capacity <= 0.0f)
                {
                    isDocked = false;
                    m_current_capacity = 0.0f;
                }
                else
                {
                    float amount_to_deliver = Math.Min(delivery_per_tick, m_current_capacity);
                    MiningInventory.Add(amount_to_deliver, m_element);
                    m_current_capacity = m_current_capacity - amount_to_deliver;
                }

                return;
            }

            if (isMining == true)
            {
                float output_per_tick = m_mining_per_sec / m_ticks_per_second;

                float capacity = m_current_capacity + output_per_tick;

                if (capacity >= m_max_capacity)
                {
                    isMining = false;
                    isReturningToShip = true;
                    m_current_capacity = m_max_capacity;

                }
                else
                {
                    m_current_capacity = m_current_capacity + output_per_tick;
                }

            }
            else
            {
                float meters_per_tick = m_meters_per_sec / m_ticks_per_second;

                if (isReturningToShip == true)
                {
                    float current_distance = m_current_distance - meters_per_tick;

                    if (current_distance <= 0)
                    {
                        isDocked = true;
                        isReturningToShip = false;
                        m_current_distance = 0;
                        return;
                    }
                    else
                    {
                        m_current_distance = current_distance;
                    }

                }
                else
                {
                    float distance = m_current_distance + meters_per_tick;

                    if (distance >= m_destination_distance)
                    {
                        isMining = true;
                        m_current_distance = m_destination_distance;

                    }
                    else
                    {
                        m_current_distance = m_current_distance + meters_per_tick;
                    }
                }
            }
        }
    }

    private float start_time;
    private float start_inventory;

    public float InputPerSecond()
    {

        // do math to get acurate rather than average:


        float seconds_since_start = (start_time + GameTime.CurrentTimeUnix / 1000);
        float inventory_delta = MiningInventory.CurrentSupply(m_element) - start_inventory;
        return inventory_delta / seconds_since_start;
    }

    //private float start_usage = 0.0f;
    //public float UsagePerSecond()
    //{
    //    // do math get acurate
    //    float seconds_since_start = (start_time + GameTime.CurrentTimeUnix / 1000);
    //    float inventory_delta = MiningDroids.CurrentUsage(m_element) - start_usage;
    //    return inventory_delta / seconds_since_start;
    //}

    private void update_interface()
    {
        m_capacity_text.text = "Capacity: " + (int)m_current_capacity + " / " + m_max_capacity;
        m_location_text.text = "Location: " + (int)m_current_distance + " / " + m_destination_distance;
    }

    private bool on_tick()
    {
        float current_tick = GameTime.CurrentTimeUnix;
        if (current_tick >= last_tick + tick_interval)
        {
            last_tick = current_tick;
            return true;
        }

        return false;
    }
}

[System.Serializable]
public enum ElementType
{
    //Nickel,
    //Iron,
    //Carbon,
    Oxygen,
    //Cobalt,
    //Water,
    //Nitrogen,
    Hydrogen,
    //Iridium,
    //Platinum,
    Aluminum,
    //Magnesium,
    //Gold,
    //Tungsten,
}