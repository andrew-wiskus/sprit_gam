using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawExplosion : MonoBehaviour
{

    private SawExplosionCombo m_combo;
    [SerializeField] private GameObject m_saw_bullet_prefab;
    [SerializeField] private Transform m_player_transform;

    public void StartSpellAnimation(SawExplosionCombo combo)
    {
        m_combo = combo;
        m_combo.isActive = true;
        StartCoroutine(spell_animation());
    }

    private IEnumerator spell_animation() // TODO: all spell animatinos should be written via animator, just coding them out for fun/sketchin ideas
    {
        float angle = 0.0f;

        StartCoroutine(wait_for_cooldown());
        for (int i = 0; i <= 120; i++)
        {
            if(i % 2 == 0)
            {
                GameObject item = (GameObject)Instantiate(m_saw_bullet_prefab, m_player_transform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, angle)));
                item.SetActive(true);

                angle = (float)i * 3.0f;
            }
        }

        for (int i = 0; i <= 120; i++)
        {
            if (i % 2 != 0)
            {
                GameObject item = (GameObject)Instantiate(m_saw_bullet_prefab, m_player_transform.position, Quaternion.Euler(new Vector3(0.0f, 0.0f, angle)));
                item.GetComponent<Projectile>().SetSpeed(4.5f);
                item.SetActive(true);

                angle = (float)i * 3.0f;
            }
        }

        yield break;
    }

    private IEnumerator wait_for_cooldown()
    {
        yield return new WaitForSeconds(0.2f);
        m_combo.isActive = false;
    }
}
