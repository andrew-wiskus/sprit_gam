using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ParticleWeaponConfig : AbstractButtonMap {

    private ParticleSystem ps;
    private WeaponStatConfig weaponStat;
    private PlayerStatConfig playerStat;
    private BulletModule bulletModule;
    private WeaponAudioModule wam;
    private BulletObject bulletObject;
    

    [SerializeField] private AudioSource weaponAudio;
    
    [SerializeField] private AudioSource collisionAudio; // Move this

    // Particle System Handling
    public List<ParticleCollisionEvent> collisionEvents;

    // public Weapon Properties
    [HideInInspector] public Sprite m_bullet_sprite; // get this from bullet module

    //[SerializeField] private bool m_trail_on;

    private float new_damage;

    private CircleCollider2D circleCol;


	void Start () {
        ps = GetComponent<ParticleSystem>();
        weaponStat = GameObject.Find("Player").GetComponentInChildren<WeaponStatConfig>();
        playerStat = GameObject.Find("Player").GetComponentInChildren<PlayerStatConfig>();
        bulletModule = GameObject.Find("Player").GetComponentInChildren<BulletModule>();
        wam = GameObject.Find("Player").GetComponentInChildren<WeaponAudioModule>();

        SetParticleData();

        weaponAudio = GetComponent<AudioSource>();
        collisionEvents = new List<ParticleCollisionEvent>();
        StartCoroutine(start_trigger_listener());
    }

    public void SetParticleData()
    {
        var main = ps.main;
        var trails = ps.trails;

        main.startColor = bulletModule.bullet.bullet_color;
        trails.colorOverLifetime = bulletModule.bullet.trail_gradient;
        main.startSpeed = bulletModule.bullet.bullet_speed;
        ps.textureSheetAnimation.SetSprite(0, bulletModule.bullet.bullet_sprite);
        //trails.enabled = m_trail_on;

        foreach (BonusStat bonusStat in bulletModule.bullet.bullet_bonus_stats)
        {
            if (bonusStat.bonus_stats == BonusEffect.Size)
            {

                main.startSizeMultiplier = main.startSizeMultiplier * (1 + bonusStat.stat_increase_amount);
            }
        }
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
        yield return new WaitForSeconds(1 / weaponStat.fire_rate);
        yield break;
    }

    
    private void FireWeapon()
    {
        AutomaticFire();
    }

    private void AutomaticFire()
    {
        if (playerStat.current_mana - bulletModule.bullet.mana_cost_per_shot > 0)
        {
            ps.Emit(1);
            playerStat.current_mana -= bulletModule.bullet.mana_cost_per_shot;
            weaponAudio.clip = wam.fire_sound[0];
            weaponAudio.Play();
        }
        
    }

    private void CalculateCritHit()
    {
        new_damage = weaponStat.damage;
        float randomNum = Mathf.Floor(Random.Range(0f, 100f));
        
        if (Mathf.Floor(randomNum) >= 100 - weaponStat.crit_chance)
        {
            // CRIT HIT
            //Debug.Log("CRIT [[HIT]], Num: " + randomNum);
            new_damage *= weaponStat.crit_multiplier;
        } else
        {
            // NO CRIT HIT
            //Debug.Log("CRIT MISS, Num: " + randomNum);
            new_damage = weaponStat.damage;
        }

    }

    public override void OnPress_X()
    {
        RefillMana();
    }

    void RefillMana()
    {
        weaponAudio.clip = wam.reload_sound;
        weaponAudio.Play();
        playerStat.current_mana = playerStat.mana_capacity;
    }


    void OnParticleCollision(GameObject other)
    {
        //damage = Random.value * 5.0f;

        if (other.CompareTag("Enemy"))
        {
            EnemyDamage enemy_damage = other.GetComponent<EnemyDamage>();
            Explodable explodable = other.GetComponent<Explodable>();
            float enemy_hp = other.GetComponent<EnemyDamage>().m_health_points;

            CalculateCritHit();
            enemy_damage.m_health_points -= new_damage;
            collisionAudio.Play();

            
            if (new_damage > weaponStat.damage)
            {
                enemy_damage.damage_text.color = Color.yellow;
                enemy_damage.damage_text.text = new_damage.ToString() + "!";
            } else
            {
                enemy_damage.damage_text.color = Color.red;
                enemy_damage.damage_text.text = new_damage.ToString();
            }
            
            StartCoroutine(ShortDelay());
            enemy_damage.m_particle_text.Emit(1);

            if (enemy_damage.m_health_points <= 0)
            {
                //Destroy(other);
                explodable.explode();
            }
        }
        
        //ParticlePhysicsExtensions.GetCollisionEvents(ps, other, collisionEvents);
    }

    private IEnumerator ShortDelay()
    {
        new WaitForEndOfFrame();
        yield break;
    }

    void FixedUpdate()
    {

    }

}
