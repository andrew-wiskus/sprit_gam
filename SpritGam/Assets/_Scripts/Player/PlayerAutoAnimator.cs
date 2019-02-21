using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAnimator : MonoBehaviour {

    private PlayerAnimation m_player_animation;

    private SpriteRenderer m_player_renderer;

    private Sprite[] run_up;
    private Sprite[] run_side;
    private Sprite[] run_down;
    private Sprite[] run_diag;
    
	void Start () {
        m_player_animation = GetComponent<PlayerAnimation>();
        m_player_renderer = GetComponentInParent<SpriteRenderer>();

        run_side = Resources.LoadAll<Sprite>("Running_w_arms");
        Debug.Log(run_side[0]);
        //Debug.Log(run_side[0].name);
	}


	
	void FixedUpdate () {
		
	}
}
