using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterButtonHandler : AbstractButtonMap {

    [SerializeField] GameObject weaponDetailDisplay;

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

}
