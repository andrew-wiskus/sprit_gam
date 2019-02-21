using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerAnimationController : MonoBehaviour
{

    [SerializeField] public float Speed = 1.0f;
    [SerializeField] public Vector2 DestinationCords;
    [SerializeField] public Vector2 DockingCords;
    private float currentCord = 0;
    public bool enRoute;
    public bool isDocked;
    public bool isMining;

    private Quaternion flyAngle;

    void Start()
    {
        LaunchFromDock();
    }

    public void LaunchFromDock()
    {
        enRoute = true;
        isDocked = false;
    }

    public void LaunchFromDestination()
    {
        enRoute = false;
        isMining = false;
    }


    void FixedUpdate()
    {
        //if(isDocked || isMining)
        //{
        //    return;
        //}

        if (currentCord >= 1 && enRoute == true)
        {
            enRoute = false;
            isMining = true;

        }
        else if (currentCord <= 0 && enRoute == false)
        {
            enRoute = true;
            isDocked = true;
        }


        if (enRoute == true)
        {
            currentCord += Time.deltaTime * Speed;
        }
        else
        {
            currentCord -= Time.deltaTime * Speed;
        }
        transform.position = Vector3.Lerp(DockingCords, DestinationCords, currentCord);
        
    }
}
