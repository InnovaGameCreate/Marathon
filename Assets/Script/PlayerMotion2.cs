using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotion2 : MonoBehaviour
{
    //マクロ
    public int jumpNum; //ジャンプ制限回数
    public float jumpForce; //ジャンプ力
    public Text SlowTimeCounter;//スローダッシュの残り時間を表示するテキスト

    //変数
    private float playerSpeed = 0f; //プレイヤー移動スピード
    private float walkForce = 100; //前進力
    private float cameraOffset; //カメラとの相対距離
    private bool slow = false; //スローダッシュフラグ
    public static int jumpCount = 0; //ジャンプ回数
    private float timeCount = 30f; //スローダッシュタイム
    public float staminaPoint = 1.0f;//スタミナ総量
    public float warterPoint = 1.0f;//水分総量

    //tmp
    public static float jumpForceTmp;

    //コンポーネント・オブジェクト
    private Rigidbody2D rb;
    [SerializeField] GameObject MainCamera;
    public static PlayerMotion2 ins;

    void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //取得
        rb = GetComponent<Rigidbody2D>();

        //初期化
        cameraOffset = MainCamera.gameObject.transform.position.x - this.transform.position.x; //相対距離取得

        //tmp
        jumpForceTmp = jumpForce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * (playerSpeed - rb.velocity.x) * walkForce);

    }

    void Update()
    {
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
        if (DestoryObject.stomachPain == 1)
        {
            slow = false;
            Distance.dash = 0f;
        }

        //ジャンプ
        if (InputOperation.input.wrp && jumpCount < jumpNum && DestoryObject.stomachPain != 1)
        {
            rb.AddForce(Vector2.up * jumpForce); //ジャンプ力
            jumpCount++; //空中でのジャンプ回数
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

        SlowTimeCounter.text = "スロー残り時間：" + timeCount.ToString("N1");

        if (this.transform.position.y < 4.0f)
        {
            Status.HealthGauge = 0;
        }

        //スピード値更新
        playerSpeed = Distance.speed * Distance.slope * Distance.dash;

        //カメラ移動
        Vector3 vec = new Vector3(this.transform.position.x + cameraOffset, 12, -10);
        MainCamera.gameObject.transform.position = vec;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //床
        if (col.gameObject.tag == "Floor")
        {
            Distance.slope = 1f;
            Status.staminaPerSec = 1f;
        }
        if (col.gameObject.tag == "FloorUp")
        {
            Distance.slope = 1.2f;
            Status.staminaPerSec = 1.2f;
        }
        if (col.gameObject.tag == "FloorDown")
        {
            Status.staminaPerSec = 1f;
        }

        //アイテム
        if (col.gameObject.tag == "Heal")
        {
            staminaPoint += 1.0f;//スタミナを1,0回復
        }

        if (col.gameObject.tag == "warter")
        {
            warterPoint += 1.0f;//水分を1,0回復
        }

        jumpCount = 0; //ジャンプ回数リセット
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //下り坂制御
        if (col.gameObject.tag == "FloorDown")
        {
            rb.AddForce(Vector2.down * (50 - rb.velocity.y) * 50);
        }
    }

    public void PlayerForce(Vector2 vec, float force)
    {
        rb.AddForce(vec * force);
    }
}
