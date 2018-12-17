using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VapeHitProjectileController : ProjectileFireSequence
{
    [SerializeField] private Animator m_vape_animator;
    [SerializeField] private WeaponAudio m_vape_audio;
    [SerializeField] private float vape_hit_duration = 0.5f;

    public override void Fire()
    {
        StartCoroutine(hit_vape_animation());
    }

    private IEnumerator hit_vape_animation()
    {
        m_vape_animator.Play("Vape_Hit");
        yield return new WaitForSeconds(0.5f);
        m_vape_audio.HitVape();
        yield return new WaitForSeconds(vape_hit_duration);
        m_vape_animator.Play("Vape_Blow");
        m_vape_audio.BlowVape();
        yield break;
    }
}