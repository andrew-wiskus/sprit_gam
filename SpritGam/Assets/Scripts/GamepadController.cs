using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;



public class GamepadController : MonoBehaviour {

    [SerializeField] public float quick_Duration;
    [SerializeField] public float medium_Duration;
    [SerializeField] public float long_Duration;

    [SerializeField] public float soft_Strength;
    [SerializeField] public float medium_Strength;
    [SerializeField] public float hard_Strength;

    private PlayerIndex playerOne = 0;

    // Use this for initialization
    void Start () {
	}

    public IEnumerator Vibrate(float duration, float strength)
    {
        GamePad.SetVibration(playerOne, strength, strength);
        yield return new WaitForSeconds(duration);
        SetNoVibration();
        yield break;
    }

    private void SetNoVibration()
    {
        GamePad.SetVibration(playerOne, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
