using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningDroidsData : MonoBehaviour {

    [SerializeField] private List<MinerDroid> m_miner_droids;

    private float last_tick = 0;
    [SerializeField] private float m_ticks_per_second;
    private float tick_interval { get { return 1000 / m_ticks_per_second; } }

    private void FixedUpdate()
    {

        if(on_tick())
        {
            float hydrogen_input_per_sec = 0.0f;

            for (int i = 0; i < m_miner_droids.Count; i++)
            {
                MinerDroid droid = m_miner_droids[i];
                switch(droid.element)
                {
                    case ElementType.Hydrogen:
                        hydrogen_input_per_sec += droid.InputPerSecond();
                        break;
                }
            }

            MiningDroids.UpdateElementInput(hydrogen_input_per_sec, ElementType.Hydrogen);
        }
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

public class MiningDroids
{

    public static Dictionary<ElementType, float> m_input_per_second = new Dictionary<ElementType, float>();
    public static Dictionary<ElementType, float> m_usage_per_second = new Dictionary<ElementType, float>();

    public static void initData()
    {
        m_input_per_second.Add(ElementType.Hydrogen, 0.0f);
    }

    public static void UpdateElementInput(float amount, ElementType type)
    {
        m_input_per_second[type] = amount;
    }

    public static float GetElementInput(ElementType type)
    {
        return m_input_per_second[type];
    }

    public static float CurrentUsage(ElementType type)
    {
       return m_usage_per_second[type];
    }
}
