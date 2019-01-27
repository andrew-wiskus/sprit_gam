using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildMenuButton : MonoBehaviour {

    [SerializeField] public Sprite itemSprite;
    // Use this for initialization

    public void setActive(bool isActive)
    {
        Image sprite = GetComponent<Image>();

        if(isActive)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
        else
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.2f);
        }
    }
}
