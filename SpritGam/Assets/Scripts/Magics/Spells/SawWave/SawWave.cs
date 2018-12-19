using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawWave : MonoBehaviour
{

    [SerializeField] List<GameObject> m_wave_1;
    [SerializeField] List<GameObject> m_wave_2;
    [SerializeField] List<GameObject> m_wave_3;

    private SawWaveCombo m_combo;
    private float m_spell_duration = 1.0f;
    private float m_started_at_time = 0.0f;

    public void StartSpellAnimation(SawWaveCombo combo)
    {
        m_combo = combo;
        m_combo.isActive = true;
        m_started_at_time = Time.time;
        StartCoroutine(start_saw_wave(m_wave_1, 0.0f));
        StartCoroutine(start_saw_wave(m_wave_2, 0.15f));
        StartCoroutine(start_saw_wave(m_wave_3, 0.30f));
    }

    private IEnumerator start_saw_wave(List<GameObject> wave_object, float delay)
    {
        yield return new WaitForSeconds(delay);
        set_sprites_active(wave_object, true);

        float angle = 0.0f;

        while (Time.time < m_started_at_time + m_spell_duration)
        {
            foreach (var item in wave_object)
            {
                item.transform.Rotate(Vector3.forward, angle);
                angle += 0.5f;
            }

            yield return null;
        }

        m_combo.isActive = false;
        set_sprites_active(wave_object, false);

        yield break;
    }

    private void set_sprites_active(List<GameObject> objects, bool active)
    {
        foreach (var item in objects)
        {
            item.SetActive(active);
        }
    }
}
