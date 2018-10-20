using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WeaponsList
{
    TOMMY_GUN,
    MOSSBERG,
    DESERT_EAGLE
}

public class PlayerWeaponStance : MonoBehaviour {

    [SerializeField] private TwinStickButtonMap twinStickButtonMap;
    [SerializeField] private GunController currentWeaponController;

    [SerializeField] private WeaponsList[] weaponsInInventory = new WeaponsList[] { WeaponsList.TOMMY_GUN, WeaponsList.MOSSBERG, WeaponsList.DESERT_EAGLE };
    
    [SerializeField] private GameObject torso;
    
    [SerializeField] private float doubleHand_TorsoAngle;
    [SerializeField] private float singleHand_TorsoAngle;
    [SerializeField] private float dualWield_TorsoAngle;
    [SerializeField] private float melee_TorsoAngle;
    [SerializeField] private float noEquip_TorsoAngle;
    
    [SerializeField] private GameObject twoHandedWeapon;
    [SerializeField] private GameObject oneHandedWeapon;
    [SerializeField] private GameObject dualWieldedWeapon;
    [SerializeField] private GameObject meleeWeapon;

    private int weaponInventoryIndex = 0;

    [SerializeField] private GameObject tommyGun;
    [SerializeField] private GameObject mossberg;
    [SerializeField] private GameObject desertEagle;

    public GameObject currentWeapon;
    public WeaponStance currentStance;

    [SerializeField] private GunGUIController m_gun_gui_controller;

    // Use this for initialization
    void Awake () {
        SetEquippedWeapon();
        currentStance = currentWeapon.GetComponent<GunController>().weaponType;
        SetTorsoAngle();
    }
    

    public void SetEquippedWeapon()
    {
        switch (weaponsInInventory[weaponInventoryIndex]){
            case WeaponsList.TOMMY_GUN:
                currentWeapon = tommyGun;
                currentWeaponController = tommyGun.GetComponent<GunController>();
                break;

            case WeaponsList.MOSSBERG:
                currentWeapon = mossberg;
                currentWeaponController = mossberg.GetComponent<GunController>();
                break;


            case WeaponsList.DESERT_EAGLE:
                currentWeapon = desertEagle;
                currentWeaponController = desertEagle.GetComponent<GunController>();
                break;
        }
        currentWeapon.SetActive(true);
        currentStance = currentWeapon.GetComponent<GunController>().weaponType;
        m_gun_gui_controller.SetCurrentWeapon(currentWeapon.name.ToString());
        SetTorsoAngle();
    }

    public void SetTorsoAngle()
    {
        switch (currentStance)
        {
            case WeaponStance.SINGLE_HAND:
                torso.transform.eulerAngles = new Vector3(0, 0, singleHand_TorsoAngle);
                
                break;

            case WeaponStance.DOUBLE_HAND:
                torso.transform.eulerAngles = new Vector3(0, 0, doubleHand_TorsoAngle);
               break;

            case WeaponStance.DUAL_WIELD:
                torso.transform.eulerAngles = new Vector3(0, 0, dualWield_TorsoAngle);
                break;

            case WeaponStance.NONE:
                torso.transform.eulerAngles = new Vector3(0, 0, noEquip_TorsoAngle);
                break;
        }
    }

    public void ToggleEquippedWeapon()
    {
        weaponInventoryIndex += 1;
        if (weaponInventoryIndex >= weaponsInInventory.Length)
        {
            weaponInventoryIndex = 0;
        }
        
        SetEquippedWeapon();
    }

    
	
	// Update is called once per frame
	void Update () {

        currentStance = currentWeapon.GetComponent<GunController>().weaponType;

        if (tommyGun != currentWeapon)
        {
            tommyGun.SetActive(false);
        }
        if (mossberg != currentWeapon)
        {
            mossberg.SetActive(false);
        }
        if (desertEagle != currentWeapon)
        {
            desertEagle.SetActive(false);
        }

        if (currentStance == WeaponStance.SINGLE_HAND)
        {
            oneHandedWeapon.SetActive(true);
            twoHandedWeapon.SetActive(false);
            dualWieldedWeapon.SetActive(false);
        }
        if (currentStance == WeaponStance.DOUBLE_HAND)
        {
            oneHandedWeapon.SetActive(false);
            twoHandedWeapon.SetActive(true);
            dualWieldedWeapon.SetActive(false);
        }
        if (currentStance == WeaponStance.DUAL_WIELD)
        {
            oneHandedWeapon.SetActive(false);
            twoHandedWeapon.SetActive(false);
            dualWieldedWeapon.SetActive(true);
        }
        
    }
}
