using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ParticleWeaponConfig : AbstractButtonMap {

    private ParticleSystem ps;
    [SerializeField] private AudioSource weaponAudio;
    [SerializeField] private AudioSource collisionAudio;

    [SerializeField] private GameObject pauseMenu;

    // Particle System Handling
    public List<ParticleCollisionEvent> collisionEvents;

    // public Weapon Properties
    [SerializeField] private float m_fire_rate;
    [SerializeField] private float m_bullet_speed;
    [SerializeField] private Sprite m_bullet_sprite;
    [SerializeField] private bool m_trail_on;

    // Sound Properties
    [SerializeField] private AudioClip m_reload_sound;
    [SerializeField] private AudioClip m_fire_sound;

    private float damage;
    public float m_default_damage;

    // MANA BAR
    //[SerializeField] private Sprite m_mana_bar_graphic;
    [SerializeField] private Image m_mana_fill_image;
    [SerializeField] private Text m_mana_text;
    [SerializeField] private Text m_reload_text;
    private float currentManaAmount;

    [SerializeField] public float m_mana_capacity;
    [SerializeField] public float m_mana_cost_per_shot;

    // CRIT SYSTEM
    [SerializeField] public float m_crit_rate;
    [SerializeField] public float m_crit_damage_factor;


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

        currentManaAmount = m_mana_capacity;
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
        Debug.Log("Particle System: " + ps);
        FireWeapon();
        yield return new WaitForSeconds(m_fire_rate);
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
        //SemiAutomaticFire();
        //ShotgunFire();
    }

    private void AutomaticFire()
    {
        if (currentManaAmount - m_mana_cost_per_shot > 0)
        {
            ps.Emit(1);
            currentManaAmount -= m_mana_cost_per_shot;
            weaponAudio.clip = m_fire_sound;
            weaponAudio.Play();
        }
        
        // set mana image fill amount
        // subtract ammo amount
        
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

    private void CalculateCritHit()
    {
        damage = m_default_damage;
        float randomNum = Mathf.Floor(Random.Range(0f, 100f));
        
        if (Mathf.Floor(randomNum) >= 100 - m_crit_rate)
        {
            // CRIT HIT
            Debug.Log("CRIT [[HIT]], Num: " + randomNum);
            damage *= m_crit_damage_factor;
        } else
        {
            // NO CRIT HIT
            Debug.Log("CRIT MISS, Num: " + randomNum);
            damage = m_default_damage;
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
        currentManaAmount = m_mana_capacity;
    }


    void OnParticleCollision(GameObject other)
    {
        //damage = Random.value * 5.0f;

        if (other.CompareTag("Enemy"))
        {
            EnemyDamage enemy_damage = other.GetComponent<EnemyDamage>();
            float enemy_hp = other.GetComponent<EnemyDamage>().m_health_points;

            CalculateCritHit();
            enemy_damage.m_health_points -= damage;
            collisionAudio.Play();

            if (enemy_damage.m_health_points <= 0)
            {
                Destroy(other);
            }

            if (damage > m_default_damage)
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
        }
        
        //ParticlePhysicsExtensions.GetCollisionEvents(ps, other, collisionEvents);
    }

    private IEnumerator ShortDelay()
    {
        new WaitForEndOfFrame();
        yield break;
    }

    private void UpdateManaGraphic()
    {
        m_mana_fill_image.fillAmount = currentManaAmount / m_mana_capacity;
        m_mana_text.text = currentManaAmount.ToString() + " / " + m_mana_capacity;

        if (currentManaAmount - m_mana_cost_per_shot < 0)
        {
            m_reload_text.enabled = true;
        }
        else
        {
            m_reload_text.enabled = false;
        }
    }

    void FixedUpdate()
    {
        UpdateManaGraphic();
    }

}
