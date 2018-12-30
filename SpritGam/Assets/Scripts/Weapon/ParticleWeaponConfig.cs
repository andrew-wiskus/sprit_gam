﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParticleWeaponConfig : AbstractButtonMap {

    [SerializeField] public ParticleSystem ps;
    [SerializeField] public GameObject dad;
    private AudioSource weaponAudio;

    // Particle System Handling
    public List<ParticleCollisionEvent> collisionEvents;
    [SerializeField] ParticleSystem m_blood_splatter;
    [SerializeField] ParticleSystem m_dust_poof;

    // public Weapon Properties
    [SerializeField] private float m_fire_rate;
    [SerializeField] private float m_bullet_speed;
    [SerializeField] private Sprite m_bullet_sprite;
    [SerializeField] private bool m_trail_on;

    public float damage = 5;

    

	void Start () {
        var main = ps.main;
        var trails = ps.trails;

        weaponAudio = GetComponent<AudioSource>();
        collisionEvents = new List<ParticleCollisionEvent>();
        StartCoroutine(start_trigger_listener());

        main.startSpeed = m_bullet_speed;
        ps.textureSheetAnimation.SetSprite(0, m_bullet_sprite);
        trails.enabled = m_trail_on;
    }

    private IEnumerator start_trigger_listener()
    {
        yield return new WaitForEndOfFrame();

        if (ControllerInput.RightTrigger() > 0.2f)
        {
            yield return pull_trigger();
        }

        yield return start_trigger_listener();
        yield break;
    }

    private IEnumerator pull_trigger()
    {
        FireWeapon();
        yield return new WaitForSeconds(m_fire_rate);
        yield break;
    }

    public override void OnPress_START()
    {
        ps.Pause();
    }

    // use one at a time, for testing purposes
    private void FireWeapon()
    {
        AutomaticFire();
        //SemiAutomaticFire();
        //ShotgunFire();
    }

    private void AutomaticFire()
    {
        ps.Emit(1);
        weaponAudio.Play();
    }

    private void SemiAutomaticFire()
    {
        ps.Emit(1);
    }

    private void ShotgunFire()
    {
        SetAsShotgun();
        ps.Emit(5);
    }

    private void SetAsShotgun()
    {
        var sh = ps.shape;
        sh.shapeType = ParticleSystemShapeType.Cone;
        sh.scale = new Vector3(0.1f, 0.98f, 0f);
        sh.angle = 0;
        sh.arc = 60;
        sh.arcMode = ParticleSystemShapeMultiModeValue.BurstSpread;
    }


    // detecting particle collision - not working
    void OnParticleCollision(GameObject other)
    {
        damage = Random.value * 5.0f;
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            EnemyDamage enemy_damage = other.GetComponent<EnemyDamage>();
            float enemy_hp = other.GetComponent<EnemyDamage>().m_health_points;
            
            enemy_damage.m_health_points -= 5f;

            if (enemy_damage.m_health_points <= 0)
            {
                Destroy(other);
            }

            enemy_damage.damage_text.text = damage.ToString();
            Debug.Log(enemy_damage.damage_text.text);
            enemy_damage.m_particle_text.Emit(1);
            Debug.Log("ENEMY HP: " + enemy_damage.m_health_points);

            // use blood splatter sub emitter
            // give damage
            // show damage amount text
            // destroy if HP = 0
        } else if (other.CompareTag("MetalObject"))
        {
            // use spark sub emitter
        } else
        {
            // use dust sub emitter
        }

        //Destroy(other);


        ParticlePhysicsExtensions.GetCollisionEvents(ps, other, collisionEvents);
        

        for (int i = 0; i < collisionEvents.Count; i++)
        {
            //EmitAtLocation(collisionEvents[i]);
        }
        
        Debug.Log("COLLISION DETECTED");
    }

    // method for manual sub emission - not working
    void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
    {
        m_blood_splatter.transform.position = particleCollisionEvent.intersection;
        m_blood_splatter.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
        m_blood_splatter.Emit(1);
        Debug.Log("SUB EMIT");
    }

    // testing particle collision detection methods, storing this here for now
    void Temp(GameObject other)
    {
        int numCollisionEvents = ParticlePhysicsExtensions.GetCollisionEvents(ps, other, collisionEvents);
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }
    }
    
    // delete?
    public override void OnPress_RIGHT_TRIGGER()
    {
        var main = ps.main;
        //main.loop = true;
        
        //ps.Play();
        //weaponAudio.Play();
    }

    // delete?
    public override void OnPress_RIGHT_TRIGGER_UP()
    {
        var main = ps.main;
        //main.loop = false;
        
        //ps.Stop();
    }
    

}
