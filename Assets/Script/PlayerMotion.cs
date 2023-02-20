using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotion : MonoBehaviour
{
    //マクロ
    public int jumpNum = 1; //空中でのジャンプ回数
    public float acceleration = 0.98f; //加速度
    public float setVelocity = 0f; //ジャンプ初速度

    //変数
    private int jumpCount = 0; //ジャンプ回数計測
    private float velocity = 0f; //降下速度
    private float timeCount = 30f; //スローダッシュのタイムカウント
    private bool slow = false; //スローダッシュフラグ
    public float staminaPoint = 1.0f;//スタミナ総量
    public float warterPoint = 1.0f;//水分総量

    [SerializeField] GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //前進
        this.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * Time.deltaTime, 0.0f, 0.0f);
        MainCamera.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * Time.deltaTime, 0.0f, 0.0f);

        //スピード変更
        if (InputOperation.input.arp && timeCount >= 0)
        {
            slow = true;
            Distance.dash = 0.5f;
        }
        if (InputOperation.input.srp)
        {
            slow = false;
            Distance.dash = 1f;
        }
        if (InputOperation.input.drp)
        {
            slow = false;
            Distance.dash = 1.5f;
        }

        //ジャンプ
        if (InputOperation.input.wrp && jumpCount < jumpNum)
        {
            velocity = setVelocity;
            this.gameObject.transform.Translate(0.0f, 0.1f, 0.0f);
            PlayerMask.playerMove = 0;
            jumpCount++; //空中でのジャンプ回数
        }

        //プレイヤー上下移動
        switch (PlayerMask.playerMove)
        {
            case 0:
                //Debug.Log("gravity");
                velocity -= acceleration * Time.deltaTime;
                this.gameObject.transform.Translate(0.0f, velocity, 0.0f); 
                //jumpCount = 1;
                break;
            case 1:
                velocity = 0;
                jumpCount = 0;
                Distance.slope = 1f;
                Status.staminaPerSec = 1f;
                break;
            case 2:
                //Debug.Log("up");
                this.gameObject.transform.Translate(0.0f, 0.15f, 0.0f);//0.15
                Distance.slope = 1.2f;
                Status.staminaPerSec = 1.2f;
                break;
            case 3:
                //Debug.Log("down");
                this.gameObject.transform.Translate(0.0f, -0.01f, 0.0f);
                Status.staminaPerSec = 1f;
                break;
        }

        //スローダッシュのタイムカウント
        if (slow)
        {
            //時間計測
            timeCount -= Time.deltaTime;

            //時間を使い切る
            if (timeCount < 0)
            {
                slow = false;
                Distance.dash = 1f;
            }
        }

        //速度割合の計算
        Status.staminaPerSec = Distance.dash * Distance.slope;

        //リピート管理
        InputOperation.input.wrp = false;
        InputOperation.input.arp = false;
        InputOperation.input.srp = false;
        InputOperation.input.drp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.tag == "Heal")
        {
            staminaPoint += 1.0f;//スタミナを1,0回復
        }

        if (other.gameObject.tag == "warter")
        {
           warterPoint += 1.0f;//水分を1,0回復
        }
    }

        }
