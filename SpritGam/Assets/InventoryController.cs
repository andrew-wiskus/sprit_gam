using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {

    [SerializeField] private GameObject m_content;
    private bool m_inventory_is_showing = false;

    public bool inventoryIsShowing()
    {
        return m_inventory_is_showing;
    }
    public void ShowInventory(bool show)
    {
        m_inventory_is_showing = show;
        m_content.SetActive(show);
    }
} 
