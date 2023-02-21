using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLeg : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            Debug.Log("nomal");
            Distance.slope = 1f;
            Status.staminaPerSec = 1f;
        }
        if (col.gameObject.tag == "FloorUp")
        {
            Debug.Log("up");
            Distance.slope = 1.2f;
            Status.staminaPerSec = 1.2f;
        }
        if (col.gameObject.tag == "FloorDown")
        {
            Debug.Log("down");
            Status.staminaPerSec = 1f;
        }

        PlayerMotion2.jumpCount = 0; //ジャンプ回数リセット
    }
}
