using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
    public GameObject player;
    private PlayerMotion playerMotionCs;

    public static  int stomachPain = 0;//0:腹痛ナシ , 1:動けない状態 , 2:食べられない状態
    private float healStomachPainTime = 0;//腹痛が治るまで必要な時間

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMotionCs = player.GetComponent<PlayerMotion>();
    }

    // Update is called once per frame
    void Update()
    {
        //腹痛の処理（5秒うごけない,30秒おにぎり食べられない）を書いている
        if (stomachPain != 0 && healStomachPainTime > 0)
        {
            healStomachPainTime -= Time.deltaTime;

            if (stomachPain == 1 && healStomachPainTime <= 25f)
            {
                Distance.dash = 1.0f;
                stomachPain = 2;
            }

            if (healStomachPainTime <= 0f)
                stomachPain = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("atatta");
        if (col.gameObject.CompareTag("JumpRamp"))
        {
            playerMotionCs.velocity = playerMotionCs.setVelocity * 1.1f;
            player.gameObject.transform.Translate(0.0f, 0.2f, 0.0f);
            PlayerMask.playerMove = 0;
            playerMotionCs.jumpCount++; //空中でのジャンプ回数
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Water"))
        {
            Status.WaterGauge = 100;
            Destroy(col.gameObject);
        }

        //障害物関係
        if (col.gameObject.CompareTag("ObstacleStone"))
        {
            Status.injuretime += 10;
            Status.injureflg = true;
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.CompareTag("ObstacleRottenOnigiri"))
        {
            stomachPain = 1;
            healStomachPainTime = 30;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("ObstacleRunner"))//綴りミスきおつけて
        {
            Distance.distance -= 1000;//走行距離の変数
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Riceball"))
        {
            if(stomachPain == 0)
            Status.SatietyGauge = 100;

            Destroy(col.gameObject);
        }
    }    
}
    
