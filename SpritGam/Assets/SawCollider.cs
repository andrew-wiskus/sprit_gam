using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCollider : MonoBehaviour {

    private CircleCollider2D m_collider;

    void Start () {
        m_collider = GetComponent<CircleCollider2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Monster")
        {
            Physics2D.IgnoreCollision(collision.collider, m_collider);
        }
    }
}
