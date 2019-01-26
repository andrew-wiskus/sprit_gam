using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterButtonHandler : AbstractButtonMap {

    [SerializeField] GameObject weaponDetailDisplay;
    [SerializeField] PlayerMovement playerMovement;


    void Start()
    {
        weaponDetailDisplay.SetActive(false);
    }

    public override void OnPress_START()
    {
        if (weaponDetailDisplay.activeSelf == false)
        {
            weaponDetailDisplay.SetActive(true);
        } else
        {
            weaponDetailDisplay.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        playerMovement.enabled = !weaponDetailDisplay.activeInHierarchy;
    }

    public override void OnPress_A()
    {
        if (weaponDetailDisplay.activeInHierarchy)
        {
            Debug.Log("Pressed A");
        }
    }


}
