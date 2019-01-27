using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildButtonListHandler : MonoBehaviour
{
    private BuildMenuButton[] m_buttons;
    public BuildMenuButton activeButton;
    private int activeIndex = 0;
    [SerializeField] Image tilePreviewImage;
   

    public void Start()
    {
        m_buttons = GetComponentsInChildren<BuildMenuButton>();
        moveSelection(Direction.NONE); 
    }

    public void selectButton()
    {
        BuildMenuButton activeButton = m_buttons[activeIndex];
        tilePreviewImage.gameObject.SetActive(true);
        tilePreviewImage.sprite = activeButton.itemSprite;
    }

    public void moveSelection(Direction direction)
    {
        Debug.Log("MOVE SELECTI");
        if(direction == Direction.UP)
        {
            int new_index = activeIndex - 1 < 0 ? m_buttons.Length - 1 : activeIndex - 1;
            activeIndex = new_index;
        }

        if(direction == Direction.DOWN)
        {
            int new_index = activeIndex + 1 == m_buttons.Length ? 0 : activeIndex + 1;
            activeIndex = new_index;
        }

        activeButton = m_buttons[activeIndex];

        for (int i = 0; i < m_buttons.Length; i++)
        {
            Debug.Log(activeIndex + " : " + i);
            m_buttons[i].setActive(i == activeIndex);
        }

    }
}

