using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockDisplay : MonoBehaviour {

    [SerializeField] Text date_text;
    [SerializeField] Text time_text;
    [SerializeField] Text am_pm;

	void FixedUpdate () {
        date_text.text = GameTime.CurrentTime.ToString("MMM dd : yyyy");
        time_text.text = GameTime.CurrentTime.ToString("hh:mm");
        am_pm.text = GameTime.CurrentTime.ToString("tt");
	}
}
