using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildModeButtonHandler : AbstractButtonMap
{

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerAim playerAim;
    [SerializeField] GameObject build_menu;
    [SerializeField] BuildModeController buildController;
    [SerializeField] BuildButtonListHandler buttonList;
    [SerializeField] GameObject tileSelector;
    [SerializeField] BuildObjectSpawner buildSpawner;

    public bool buildModeIsActive = false;
    private bool is_in_menu = false;

    void Start()
    {
        build_menu.SetActive(false);
    }

    public override void OnPress_START()
    {
        if (build_menu.activeSelf == false)
        {
            build_menu.SetActive(true);
            is_in_menu = true;
        }
        else
        {
            build_menu.SetActive(false);
            is_in_menu = false;
        }
    }

    void FixedUpdate()
    {
        buildModeIsActive = !build_menu.activeInHierarchy;
        playerMovement.enabled = buildModeIsActive;
        playerAim.enabled = buildModeIsActive;
    }

    public override void OnPress_A()
    {
        if(is_in_menu)
        {
            tileSelector.SetActive(true);
            //build_menu.SetActive(false);
            buttonList.selectButton();
            is_in_menu = false;
        } else
        {
            Debug.Log(buttonList == null);
            Debug.Log(buttonList.activeButton == null);
            Debug.Log(buttonList.activeButton.itemSprite == null);
            buildSpawner.SpawnItem(tileSelector.transform.position, buttonList.activeButton.itemSprite);
        }
    }

    private bool m_dpad_is_up = true;

    public override void OnPress_DPAD_UP()
    {
        if (m_dpad_is_up == false) { return; }

        if (is_in_menu)
        {
            buttonList.moveSelection(Direction.UP);
        }
        else
        {
            buildController.moveTileSelector(Direction.UP);
        }
        m_dpad_is_up = false;
    }

    public override void OnPress_DPAD_LEFT()
    {
        if (m_dpad_is_up == false) { return; }
        if (is_in_menu == false) { 
            buildController.moveTileSelector(Direction.LEFT);
        }
        m_dpad_is_up = false;
    }

    public override void OnPress_DPAD_RIGHT()
    {
        if (m_dpad_is_up == false) { return; }
        Debug.Log("RIGHJT!");
        if (is_in_menu == false) { 
            buildController.moveTileSelector(Direction.RIGHT);
        }
        m_dpad_is_up = false;
    }

    public override void OnPress_DPAD_DOWN()
    {
        if (m_dpad_is_up == false) { return; }
        if (is_in_menu)
        {
            buttonList.moveSelection(Direction.DOWN);
        }
        else
        {
            buildController.moveTileSelector(Direction.DOWN);
        }
        m_dpad_is_up = false;
    }

    public override void OnPress_NO_DPAD()
    {
        m_dpad_is_up = true;
    }
}

public enum Direction
{
    DOWN,
    LEFT,
    RIGHT,
    UP,
    NONE
}