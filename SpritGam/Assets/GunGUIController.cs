﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunGUIController : MonoBehaviour {

    [SerializeField] private Text m_clip_status;
    [SerializeField] private Text m_clip_status_graphic; //temp using text; update this to graphic 

    public void SetClipStatus(int current_ammo, int max_ammo)
    {
        //set text
        string prefix = current_ammo >= 10 && max_ammo >= 10 ? "" : "0";
        m_clip_status.text = prefix + current_ammo.ToString() + " / " + max_ammo;

        //set text graphic (same idea applys with an array of images, just hide + show)
        float ammo_left_percent = (float)current_ammo / (float)max_ammo;
        float max_graphics_to_show = 20.0f; // ammo_graphics.length;
        int current_graphics_to_show = Mathf.FloorToInt(max_graphics_to_show * ammo_left_percent);
        m_clip_status_graphic.text = new string('|', current_graphics_to_show);
    }
}