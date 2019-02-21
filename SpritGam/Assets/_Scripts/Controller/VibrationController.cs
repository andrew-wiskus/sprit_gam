using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;


public class VibrationController : MonoBehaviour {

    private PlayerIndex m_player_one = 0;
    public bool ToggleVibration = true;

    public void Vibrate(float duration, float strength)
    {
        if(ToggleVibration == false)
        {
            return;
        }

        StartCoroutine(vibrate_action(duration, strength));
    }

    private IEnumerator vibrate_action(float duration, float strength)
    {
        GamePad.SetVibration(m_player_one, strength, strength);
        yield return new WaitForSeconds(duration);
        SetNoVibration();
        yield break;
    }
    private void SetNoVibration()
    {
        GamePad.SetVibration(m_player_one, 0, 0);
        GamePadDPad dpad = GetComponent<GamePadDPad>();
        //dpad.Down
    }
}
