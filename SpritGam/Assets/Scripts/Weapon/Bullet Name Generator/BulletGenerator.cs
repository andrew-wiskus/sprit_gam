using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour {

    public string generated_bullet_name;
    private BulletAdj m_adj;
    private BulletNoun m_noun;

	void Start () {
        m_adj = GetComponent<BulletAdj>();
        m_noun = GetComponent<BulletNoun>();
        GenerateNewBullet();
	}
	
	public void GenerateNewBullet()
    {
        int adj_int = Random.Range(0, m_adj.bullet_adj.Length);
        int noun_int = Random.Range(0, m_noun.bullet_noun.Length);

        /// adj + noun
        generated_bullet_name = m_adj.bullet_adj[adj_int].ToString() + " " + m_noun.bullet_noun[noun_int].ToString();
    }
}
