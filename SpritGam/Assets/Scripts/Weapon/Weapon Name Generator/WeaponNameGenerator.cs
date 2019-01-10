using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNameGenerator : MonoBehaviour {

    public string generated_weapon_name;
    private WeaponAdj m_adj;
    private WeaponNoun m_noun;

    void Start()
    {
        m_adj = GetComponent<WeaponAdj>();
        m_noun = GetComponent<WeaponNoun>();
        GenerateNewWeaponName();
    }

    public void GenerateNewWeaponName()
    {
        int adj_int = Random.Range(0, m_adj.weapon_adj.Length);
        int noun_int = Random.Range(0, m_noun.weapon_noun.Length);

        /// adj + noun
        generated_weapon_name = m_adj.weapon_adj[adj_int].ToString() + " " + m_noun.weapon_noun[noun_int].ToString();

        /// adj + noun + noun
        // int noun_int_2 = Random.Range(0, m_noun.weapon_noun.Length);     generated_weapon_name = m_adj.weapon_adj[adj_int].ToString() + " " + m_noun.weapon_noun[noun_int].ToString() + " " + m_noun.weapon_noun[noun_int_2].ToString();
    }
}
