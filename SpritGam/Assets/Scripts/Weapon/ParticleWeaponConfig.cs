using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ParticleWeaponConfig : AbstractButtonMap {

    private ParticleSystem ps;
    private WeaponStatConfig weaponStat;
    private PlayerStatConfig playerStat;

    [SerializeField] private AudioSource weaponAudio;
    [SerializeField] private AudioSource collisionAudio;

    [SerializeField] private GameObject pauseMenu;

    // Particle System Handling
    public List<ParticleCollisionEvent> collisionEvents;

    // public Weapon Properties
    [SerializeField] private Sprite m_bullet_sprite;
    [SerializeField] private bool m_trail_on;

    // Sound Properties
    [SerializeField] private AudioClip m_reload_sound;
    [SerializeField] private AudioClip m_fire_sound;

    private float damage;
    public float m_default_damage;

    private CircleCollider2D circleCol;


	void Start () {
        ps = GetComponent<ParticleSystem>();
        weaponStat = GameObject.Find("Player").GetComponentInChildren<WeaponStatConfig>();
        playerStat = GameObject.Find("Player").GetComponentInChildren<PlayerStatConfig>();


        var main = ps.main;
        var trails = ps.trails;

        weaponAudio = GetComponent<AudioSource>();
        collisionEvents = new List<ParticleCollisionEvent>();
        StartCoroutine(start_trigger_listener());

        ps.textureSheetAnimation.SetSprite(0, m_bullet_sprite);
        trails.enabled = m_trail_on;
        
        damage = m_default_damage;
        pauseMenu.SetActive(false);
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
        yield return new WaitForSeconds(weaponStat.fire_rate);
        yield break;
    }

    // TODO: move this to new Pause script
    public override void OnPress_START()
    {
        if (pauseMenu.activeSelf == false)
        {
            ps.Pause();
            pauseMenu.SetActive(true);
        } else
        {
            ps.Play();
            pauseMenu.SetActive(false);
        }
        
    }

    // use one at a time (for testing purposes)
    private void FireWeapon()
    {
        AutomaticFire();
    }

    private void AutomaticFire()
    {
        if (playerStat.current_mana - weaponStat.mana_cost_per_shot > 0)
        {
            ps.Emit(1);
            playerStat.current_mana -= weaponStat.mana_cost_per_shot;
            weaponAudio.clip = m_fire_sound;
            weaponAudio.Play();
        }
        
    }

    private void CalculateCritHit()
    {
        damage = weaponStat.damage;
        float randomNum = Mathf.Floor(Random.Range(0f, 100f));
        
        if (Mathf.Floor(randomNum) >= 100 - weaponStat.crit_chance)
        {
            // CRIT HIT
            Debug.Log("CRIT [[HIT]], Num: " + randomNum);
            damage *= weaponStat.crit_multiplier;
        } else
        {
            // NO CRIT HIT
            Debug.Log("CRIT MISS, Num: " + randomNum);
            damage = weaponStat.damage;
        }

    }

    public override void OnPress_X()
    {
        RefillMana();
    }

    void RefillMana()
    {
        weaponAudio.clip = m_reload_sound;
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
            enemy_damage.m_health_points -= damage;
            collisionAudio.Play();

            
            if (damage > weaponStat.damage)
            {
                enemy_damage.damage_text.color = Color.yellow;
                enemy_damage.damage_text.text = damage.ToString() + "!";
            } else
            {
                enemy_damage.damage_text.color = Color.red;
                enemy_damage.damage_text.text = damage.ToString();
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
