using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageController : MonoBehaviour {

    //[SerializeField] private GameObject self;
    //[SerializeField] private GameObject bullet;

	// Use this for initialization
	void Start () {

	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("HIT ENEMY");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Collideable")
        {
            Destroy(gameObject);
        }
    }




    // Update is called once per frame
    void Update () {
		
	}
}
