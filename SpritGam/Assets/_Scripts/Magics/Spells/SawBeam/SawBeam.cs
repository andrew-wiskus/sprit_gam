using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBeam : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_buzz_saw_sprites = new List<GameObject>();
    private SawBeamCombo m_combo;
    public void StartSpellAnimation(SawBeamCombo combo)
    {
        m_combo = combo;
        m_combo.isActive = true;
        StartCoroutine(spell_animation());
    }

    private IEnumerator spell_animation()
    {
        set_sprites_active(true);

            float angle = 0.0f;

        while (angle < 360.0f)
        {
            foreach (var item in m_buzz_saw_sprites)
            {
                item.transform.Rotate(Vector3.forward, angle);
                angle += 0.5f;
            }

            yield return null;
        }

        m_combo.isActive = false;
        set_sprites_active(false);

    }

    private void set_sprites_active(bool active)
    {
        foreach (var item in m_buzz_saw_sprites)
        {
            item.SetActive(active);
        }
    }
} 
