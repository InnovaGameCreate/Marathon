using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Distance : MonoBehaviour
{
    //マクロ
    public static float speed = 6f; // m/s基本スピード4

    //変数
    public static float slope = 1f; //坂道のスピード倍率
    public static float dash = 1f; //プレイヤーの走り倍率
    public static float distance;//プレイヤー走行距離
    public static float SPS = 40f; //距離計算をするための変数

    public static float timer;//ゲームオーバーになるまでどれほどの時間走ったか

    //オブジェクト
    public Text timeLabel;
    public Text distanceLabel;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        distance = 0f;
        timer = 0f;
    }



    // Update is called once per frame
    void Update()
    {
        //距離計算
        distance += (SPS * slope * dash * PlayerMotion.windDebuff *Time.deltaTime);
        distance = System.Math.Max(0, distance);

        //時間計算
        timer += Time.deltaTime;

        //距離の表示
        if(distanceLabel != null)
        distanceLabel.text = "距離：" + distance.ToString("N1") + "m";

        //時間の表示
        if (timeLabel != null)
            timeLabel.text = "経過時間：" + timer.ToString("0") + "秒";

        //Debug.Log(SPS);
    }

    
}
