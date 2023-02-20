using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
    public GameObject player;
    private PlayerMotion playerMotionCs;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMotionCs = player.GetComponent<PlayerMotion>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Item_fetcher")
        {
            Debug.Log("atatta");
            if (this.gameObject.tag == "JumpRamp")
            {
                playerMotionCs.velocity = playerMotionCs.setVelocity * 1.1f;
                player.gameObject.transform.Translate(0.0f, 0.2f, 0.0f);
                PlayerMask.playerMove = 0;
                playerMotionCs.jumpCount++; //空中でのジャンプ回数
                Destroy(this.gameObject);

            }

            
            if (this.gameObject.tag == "Riceball")
            {
                Status.SatietyGauge = 100;
                //playerMotionCs.staminaPoint += 1.0f;//スタミナを1,0回復
                Destroy(this.gameObject);
            }

            if (this.gameObject.tag == "Water")
            {
                Status.WaterGauge = 100;
                //playerMotionCs.warterPoint += 1.0f;//水分を1,0回復
                Destroy(this.gameObject);
            }

               

        }
        
    }

    /*このオブジェクトが画面外に出ると呼ばれる*/
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
