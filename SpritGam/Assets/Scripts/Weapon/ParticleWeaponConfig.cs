using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleWeaponConfig : AbstractButtonMap {

    [SerializeField] public ParticleSystem ps;
    [SerializeField] public GameObject dad;

	void Start () {
        //dad.SetActive(false);
    }

    public override void OnPress_RIGHT_TRIGGER()
    {
        var main = ps.main;
        //main.loop = true;
        //dad.SetActive(true);
        
        ps.Play();
        //ps.Play();
    }

    public override void OnPress_RIGHT_TRIGGER_UP()
    {
        var main = ps.main;
        //main.loop = false;
        //dad.SetActive(false);
        
        //ps.Stop();

    }

    // Update is called once per frame

}
