using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
    public GameObject player;
    private PlayerMotion playerMotionCs;

    [SerializeField] AudioSource AS;
    public AudioClip get;

    public static  int stomachPain;//0:腹痛ナシ , 1:動けない状態 , 2:食べられない状態
    private float healStomachPainTime;//腹痛が治るまで必要な時間

    public static bool energyflg;
    public static int energyCount;
    private float energyTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMotionCs = player.GetComponent<PlayerMotion>();
        AS = GetComponent<AudioSource>();

        stomachPain = 0;
        healStomachPainTime = 0;

        energyflg = false;
        energyCount = 1;
        energyTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //腹痛の処理（5秒うごけない,20秒おにぎり食べられない）を書いている
        if (stomachPain != 0 && healStomachPainTime > 0)
        {
            healStomachPainTime -= Time.deltaTime;

            if (stomachPain == 1 && healStomachPainTime <= 15f)
            {
                Distance.dash = 1.0f;
                stomachPain = 2;
            }

            if (healStomachPainTime <= 0f)
                stomachPain = 0;
        }

        //エナジー状態を解除するためのタイマー
        if (energyflg == true && energyTime > 0)
        {
            energyTime -= Time.deltaTime;

            if (energyTime <= 0f)
            {
                energyCount = 1;
                energyflg = false;
            }
                

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("atatta");
        AS.PlayOneShot(get);

        if (col.gameObject.CompareTag("JumpRamp"))
        {
            playerMotionCs.velocity = playerMotionCs.setVelocity * 1.2f;
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
            healStomachPainTime = 20;
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

        if (col.gameObject.CompareTag("EnergyDrink"))
        {
            Status.StaminaGauge += 10;
            energyCount = 2;
            energyTime += 10;
            energyflg = true;

            Destroy(col.gameObject);
        }
    }    
}
    
