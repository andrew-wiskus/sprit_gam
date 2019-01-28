using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipButtonHandler : AbstractButtonMap {

    public static bool isNearElementCollector = false;
    public static bool isUsingElementCollector = false;

    [SerializeField] private PlayerInputController m_player_input_controller;
    [SerializeField] private GameObject m_element_collector_screen;

    public void Start()
    {
        hide_all_menus();
    }

    private void hide_all_menus()
    {
        m_element_collector_screen.SetActive(false);
    }
    public override void OnPress_B()
    {
        if(SpaceshipButtonHandler.isNearElementCollector)
        {
            toggleElementCollectorScreen();
            return;
        }

    }

    private void toggleElementCollectorScreen()
    {
        bool shouldOpen = !SpaceshipButtonHandler.isUsingElementCollector;

        SpaceshipButtonHandler.isUsingElementCollector = shouldOpen;
        m_element_collector_screen.SetActive(shouldOpen);
        m_player_input_controller.Pause(shouldOpen);
    }

}
