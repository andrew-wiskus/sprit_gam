using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoOpenGate : MonoBehaviour {

    // note, trigger is triggered on init??
    private bool initial_lol = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(initial_lol)
        {
            GetComponent<Animator>().Play("GateOpen");

        }

        initial_lol = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Animator>().Play("GateClose");
    }
}
