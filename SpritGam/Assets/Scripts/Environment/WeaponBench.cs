using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponBench : AbstractButtonMap {

    [SerializeField] private Text enterText;
    [SerializeField] private GameObject weaponStatDisplay;
    private bool using_bench = false;
    private bool near_bench = false;

    private WeaponNameGenerator wng;
    private BulletGenerator bg;

	// Use this for initialization
	void Start () {
        enterText.enabled = false;
        wng = GetComponentInChildren<WeaponNameGenerator>();
        bg = GetComponentInChildren<BulletGenerator>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        near_bench = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        near_bench = false;
        using_bench = false;
    }

    public override void OnPress_B()
    {
        if (near_bench)
        {
            if (!using_bench)
            {
                using_bench = true;
            } else
            {
                using_bench = false;
            }
        }
    }

    public override void OnPress_Y()
    {
        if (using_bench)
        {
            wng.GenerateNewWeaponName();
        }
    }

    public override void OnPress_A()
    {
        if (using_bench)
        {
            bg.GenerateNewBullet();
        }
    }

    // Update is called once per frame
    void Update () {
		if (near_bench)
        {
            enterText.enabled = true;
        } else
        {
            enterText.enabled = false;
        }
        if (using_bench && near_bench)
        {
            weaponStatDisplay.SetActive(true);
        } else
        {
            weaponStatDisplay.SetActive(false);
        }
	}
}
