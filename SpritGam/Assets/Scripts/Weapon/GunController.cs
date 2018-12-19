using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public enum GunFireStyle
{
    AUTOMATIC,
    SEMI_AUTOMATIC,
}

public class GunController : MonoBehaviour
{
    private bool m_trigger_was_toggled = true;
    [SerializeField] public GunProperties m_current_weapon;

    // TODO: public void SwitchWeapon();

    private void OnEnable()
    {
        StartCoroutine(start_trigger_listener());
        m_current_weapon.gameObject.SetActive(true);
    }

    private IEnumerator start_trigger_listener()
    {
        yield return new WaitForEndOfFrame();

        if (m_current_weapon.weapon_is_reloading == false && ControllerInput.RightTrigger() > 0.2f)
        {
            yield return pull_gun_trigger();
        }

        yield return start_trigger_listener();
        yield break;
    }

    private IEnumerator pull_gun_trigger()
    {

        switch (m_current_weapon.fire_styles[m_current_weapon.current_fire_style_index])
        {
            case GunFireStyle.AUTOMATIC:
                m_current_weapon.FireWeapon();
                yield return new WaitForSeconds(m_current_weapon.fire_rate_in_seconds);

                break;

            case GunFireStyle.SEMI_AUTOMATIC:

                m_current_weapon.FireWeapon();
                while (ControllerInput.RightTrigger() > 0.2f)
                {
                    yield return null;
                }
                yield break;

            default:
                m_current_weapon.FireWeapon();
                yield return new WaitForSeconds(m_current_weapon.fire_rate_in_seconds);

                break;
        }

        yield break;
    }

    public void Reload()
    {
        m_current_weapon.Reload();
    }

    public void ToggleFireStyle()
    {
        m_current_weapon.ToggleFireStyle();
    }
}

