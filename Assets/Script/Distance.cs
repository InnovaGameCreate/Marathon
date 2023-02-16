using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    //マクロ
    public static float speed = 4f; // m/s基本スピード

    //変数
    public static float slope = 1f; //坂道のスピード倍率
    public static float dash = 1f; //プレイヤーの走り倍率
    public static float distance = 0f; //プレイヤー走行距離
    public static float SPS = 40f; //距離計算をするための変数

    //オブジェクト
    public Text distanceLabel;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        //距離計算
        distance += (SPS * slope * dash * Time.deltaTime);

        //距離の表示
        distanceLabel.text = "距離：" + distance.ToString("N1");
    }
}
