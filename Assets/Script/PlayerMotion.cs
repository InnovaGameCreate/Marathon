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
    public int jumpCount = 0; //ジャンプ回数計測
    public float velocity = 0f; //降下速度
    private float timeCount = 30f; //スローダッシュのタイムカウント
    public Text SlowTimeCounter;//スローダッシュの残り時間を表示するテキスト
    public static float stamina = 1.0f; //スタミナ消費量
    public float staminaPoint = 1.0f;//スタミナ総量
    public float warterPoint = 1.0f;//水分総量
    private int dashNum = 1; //ダッシュ番号
    private bool slowDash = true; //スローダッシュフラグ
    private bool quickDash = true; //クイックダッシュフラグ
    private  bool grav = false; //重力フラグ

    public static float windDebuff;

    [SerializeField] GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        windDebuff = 1.0f;
    }

    void FixedUpdate()
    {
        //重力
        if (grav)
        {
            velocity -= acceleration * Time.deltaTime;
            this.gameObject.transform.Translate(0.0f, velocity, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Weather.weatherNo == 4)
        {
            windDebuff = 0.8f;
        }
        else
        {
            windDebuff = 1.0f;
        }
        Debug.Log(windDebuff);
        //前進
        this.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * DestoryObject.energyCount * windDebuff* Time.deltaTime, 0.0f, 0.0f);
        MainCamera.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * DestoryObject.energyCount * windDebuff * Time.deltaTime, 0.0f, 0.0f);

        //ダッシュ切り替え
        if (InputOperation.input.arp && slowDash && DestoryObject.energyflg != true) dashNum = 0;
        if (InputOperation.input.srp) dashNum = 1;
        if (InputOperation.input.drp && quickDash) dashNum = 2;

        //条件判定
        if (slowDash)
        {
            if (timeCount < 0)
            {
                slowDash = false;
                dashNum = 1;
            }
        }

        if (quickDash == true)
        {
            if (Status.StaminaGauge <= 0)
            {
                quickDash = false;
                dashNum = 1;
            }
        }
        else
        {
            if (Status.StaminaGauge > 0)
            {
                quickDash = true;
                dashNum = 1;
            }
        }

        //ダッシュ
        switch (dashNum)
        {
            case 0:
                timeCount -= Time.deltaTime; //時間計測
                Distance.dash = 0.5f;
                Status.staminaPerSec = 0;
                break;
            case 1:
                Distance.dash = 1f;
                Status.staminaPerSec = Distance.dash * Distance.slope;
                break;
            case 2:
                Distance.dash = 1.5f;
                Status.staminaPerSec = Distance.dash * Distance.slope;
                break;
        }

        if (DestoryObject.stomachPain == 1)
        {
            Distance.dash = 0f;
        }

        //プレイヤー上下移動
        switch (PlayerMask.playerMove)
        {
            case 0:
                grav = true;
                //Debug.Log("gravity");
                //velocity -= acceleration * Time.deltaTime;
                //this.gameObject.transform.Translate(0.0f, velocity, 0.0f); 
                //jumpCount = 1;
                break;
            case 1:
                grav = false;
                velocity = 0;
                jumpCount = 0;
                Distance.slope = 1f;
                break;
            case 2:
                grav = false;
                //Debug.Log("up");
                this.gameObject.transform.Translate(0.0f, 0.15f, 0.0f);//0.15
                Distance.slope = 1.2f;
                break;
            case 3:
                grav = false;
                //Debug.Log("down");
                this.gameObject.transform.Translate(0.0f, -0.01f, 0.0f);
                break;
        }

        //ジャンプ
        if (InputOperation.input.wrp && jumpCount < jumpNum && DestoryObject.stomachPain != 1)
        {
            velocity = setVelocity;
            this.gameObject.transform.Translate(0.0f, 1f, 0.0f);
            PlayerMask.playerMove = 0;
            jumpCount++; //空中でのジャンプ回数
        }

        //リピート管理
        InputOperation.input.wrp = false;
        InputOperation.input.arp = false;
        InputOperation.input.srp = false;
        InputOperation.input.drp = false;

        SlowTimeCounter.text = "スロー残り時間：" + timeCount.ToString("N1");

        if (this.transform.position.y < 5.0f)
        {
            Status.HealthGauge = 0;
        }

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
