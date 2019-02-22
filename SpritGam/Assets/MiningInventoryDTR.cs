using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiningInventoryDTR : MonoBehaviour
{

    [SerializeField] private Text m_hydrogen_supply_text;
    [SerializeField] private Text m_hydrogen_input_text;
    [SerializeField] private Text m_hydrogen_useage_text;
    [SerializeField] private Text m_hydrogen_net_text;

    private void Start()
    {
        MiningDroids.initData();
    }
    void Update()
    {
        update_ui();
    }

    private void update_ui()
    {
        m_hydrogen_supply_text.text = Mathf.FloorToInt(MiningInventory.CurrentSupply(ElementType.Hydrogen)).ToString();
        m_hydrogen_input_text.text = Mathf.FloorToInt(MiningDroids.GetElementInput(ElementType.Hydrogen)) + " / s";
        m_hydrogen_useage_text.text = "0 / s";
        m_hydrogen_net_text.text = "0 / s";
    }
}
