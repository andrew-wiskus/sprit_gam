using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] public ParticleSystem m_particle_text;
    [SerializeField] public Text damage_text;

    public float m_health_points = 25;

	// Use this for initialization
	void Start () {
		
	}

    void OnParticleCollision(GameObject other)
    {
        //other.GetComponent<ParticleWeaponConfig>().damage;
        //Debug.Log("Hit by particle " + other.GetComponent<ParticleWeaponConfig>().damage);
        //Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
