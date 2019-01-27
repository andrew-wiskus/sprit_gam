using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildObjectSpawner : MonoBehaviour {

    public void SpawnItem(Vector3 position, Sprite sprite)
    {
        GameObject new_panel = new GameObject();
        new_panel.transform.parent = gameObject.transform;
        Image image = new_panel.AddComponent<Image>();
        RectTransform panel_rect = new_panel.GetComponent<RectTransform>();
        panel_rect.position = position;
        panel_rect.sizeDelta = new Vector2(1, 1);
        panel_rect.pivot = Vector2.zero;
        image.sprite = sprite;
    }
}
