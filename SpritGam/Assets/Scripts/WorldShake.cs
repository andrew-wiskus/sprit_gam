using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShake : MonoBehaviour {

    //[SerializeField] Camera testCam;
    //[SerializeField] GameObject worldSpace;
    //[SerializeField] GunController gc;
    [SerializeField] TwinStickMovement tsm;
    private GunController gc;
    [SerializeField] GameObject player;

    // Use this for initialization
    void Start () {
		
	}

    public IEnumerator ShakeWorld()
    {
        var worldPos = transform.localPosition;
        var playerPos = player.transform.localPosition;
        //float xInc = 0.1f;
        //float yInc = 0.3f;
        float xInc = 0.1f;
        float yInc = 0.3f;
        float shakeTime = 0.05f;
        float autoDif = 0.05f;

        var worldPos_start = transform.localPosition;
        var worldPos_end = new Vector3(worldPos_start.x - xInc, worldPos_start.y - yInc, worldPos_start.z);


        //switch (gc.m_fire_styles[gc.m_fire_style_index])
        //{
        //    case GunFireStyle.SEMI_AUTOMATIC:
        //        shakeTime = 0.08f;
        //        break;

        //    case GunFireStyle.SHOTGUN_PUMP:
        //    case GunFireStyle.SHOTGUN_SEMIAUTO:
        //        xInc = 0.2f;
        //        yInc = 0.5f;
        //        shakeTime = 0.14f;
        //        break;

        //    case GunFireStyle.AUTOMATIC:
        //    case GunFireStyle.BURST_AUTOMATIC:
        //    case GunFireStyle.BURST_SEMIAUTOMATIC:
        //        xInc = 0.1f;
        //        yInc = 0.3f;
        //        shakeTime = gc.m_fire_rate_in_seconds - autoDif;

        //        if (gc.m_fire_rate_in_seconds <= autoDif)
        //        {
        //            xInc = 0.08f;
        //            yInc = 0.1f;
        //            shakeTime = 0.03f;
        //        }
        //        break;
        //}

        transform.position = Vector3.Lerp(transform.position, worldPos_end, 0.1f);
        yield return new WaitForSeconds(shakeTime);
        transform.position = Vector3.Lerp(transform.position, worldPos_start, 0.1f);

        //worldPos = new Vector3(worldPos.x - xInc, worldPos.y - yInc, worldPos.z);
        //transform.localPosition = worldPos;
        //playerPos = new Vector3(playerPos.x - xInc / 2, playerPos.y - yInc / 2, playerPos.z);
        //player.transform.localPosition = playerPos;

        //yield return new WaitForSeconds(shakeTime);

        //worldPos = new Vector3(worldPos.x + xInc, worldPos.y + yInc, worldPos.z);
        //transform.localPosition = worldPos;
        //playerPos = new Vector3(playerPos.x + xInc /2, playerPos.y + yInc /2, playerPos.z);
        //player.transform.localPosition = playerPos;

        yield break;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
