using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningInventoryData : MonoBehaviour
{
    void Start()
    {
        MiningInventory.InitSupply();
    }
}

public class MiningInventory
{
    public static MiningInventory instance;

    private static Dictionary<ElementType, float> m_supply = new Dictionary<ElementType, float>();

    public static void InitSupply()
    {
        // assert that this doesn't get called twice;

        m_supply[ElementType.Hydrogen] = 0.0f;
        Add(10.0f, ElementType.Hydrogen);
        Debug.Log(m_supply[ElementType.Hydrogen]);
    }
    public static float CurrentSupply(ElementType type)
    {
        return m_supply[type];
    }

    public static void Add(float amount, ElementType type)
    {
        float current = m_supply[type];
        float new_value = current + amount;
        m_supply[type] = new_value;
    }

    public static void Remove(float amount, ElementType type)
    {
        float current = m_supply[type];
        float new_value = current - amount;
        m_supply[type] = new_value;
    }
}