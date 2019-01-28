using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{

    public void Pause(bool shouldPase)
    {
        PlayerAim aim = GetComponent<PlayerAim>();
        aim.Pause(shouldPase);

        PlayerMovement movement = GetComponent<PlayerMovement>();
        movement.Pause(shouldPase);
    }
}