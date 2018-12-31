using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParticleWeaponConfig : AbstractButtonMap {

    private ParticleSystem ps;
    private AudioSource weaponAudio;

    // Particle System Handling
    public List<ParticleCollisionEvent> collisionEvents;

    // public Weapon Properties
    [SerializeField] private float m_fire_rate;
    [SerializeField] private float m_bullet_speed;
    [SerializeField] private Sprite m_bullet_sprite;
    [SerializeField] private bool m_trail_on;

    public float damage;


	void Start () {
        ps = GetComponent<ParticleSystem>();
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

    // TODO: move this to new Pause script
    public override void OnPress_START()
    {
        ps.Pause();
    }

    // use one at a time (for testing purposes)
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

    
    void OnParticleCollision(GameObject other)
    {
        //damage = Random.value * 5.0f;

        if (other.CompareTag("Enemy"))
        {
            EnemyDamage enemy_damage = other.GetComponent<EnemyDamage>();
            float enemy_hp = other.GetComponent<EnemyDamage>().m_health_points;
            
            enemy_damage.m_health_points -= damage;

            if (enemy_damage.m_health_points <= 0)
            {
                Destroy(other);
            }

            enemy_damage.damage_text.text = damage.ToString();
            enemy_damage.m_particle_text.Emit(1);
        }
        
        //ParticlePhysicsExtensions.GetCollisionEvents(ps, other, collisionEvents);
    }
    

}
