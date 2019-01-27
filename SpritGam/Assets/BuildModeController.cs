using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeController : MonoBehaviour {

    [SerializeField] private BuildModeButtonHandler buttonHandler;
    private bool buildModeIsActive { get {  return buttonHandler.buildModeIsActive;  } }
    [SerializeField] private GameObject selector_tile;
    [SerializeField] private GameObject m_player;

    private void Start()
    {
        Vector3 refrence = m_player.transform.position + Vector3.one + Vector3.one;
        Vector3 new_position = new Vector3(Mathf.FloorToInt(refrence.x), Mathf.FloorToInt(refrence.y), refrence.z);
        selector_tile.transform.position = new_position;
    }

    public void moveTileSelector(Direction direction)
    {
        Vector3 movement = new Vector3();

        switch(direction)
        {
            case Direction.UP:
                movement = new Vector3(0, 1, 0);
                break;
            case Direction.DOWN:
                movement = new Vector3(0, -1, 0);
                break;
            case Direction.LEFT:
                movement = new Vector3(-1, 0, 0);
                break;
            case Direction.RIGHT:
                movement = new Vector3(1, 0, 0);
                break;
        }

        selector_tile.transform.position = selector_tile.transform.position + movement;
    }
}
