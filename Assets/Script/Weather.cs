using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    //マクロ
    public int CycleTime = 60; //周期タイム

    //変数
    public static int weatherNo; //天気No
    private float timeCount; //タイムカウント
    private float randomValue; //確率値

    private GameObject player;
    public GameObject Rain;
    public GameObject Snow;
    public GameObject Wind;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        weatherNo = 0;
        timeCount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //計測
        timeCount += Time.deltaTime;

        if (timeCount >= CycleTime)
        {
            //カウントリセット
            timeCount = 0;

            //天気の計算
            weatherNo = WeatherProbability(weatherNo);

            if (weatherNo == 3)
                Rain.SetActive(true);
            else if(weatherNo != 3)
                Rain.SetActive(false);

            if (weatherNo == 4)
                Wind.SetActive(true);
            else if (weatherNo != 4)
                Wind.SetActive(false);

            if (weatherNo == 5)
                Snow.SetActive(true);
            else if (weatherNo != 5)
                Snow.SetActive(false);

            Debug.Log(weatherNo);
        }
    }

    int WeatherProbability(int no)
    {
        //返り値
        int ret = 0;

        //ランダム値
        randomValue = Random.value;
        
        //天気の決定
        switch (no)
        {
            //快晴0
            //猛暑1
            //曇り2
            //大雨3
            //暴風4
            //極寒（雪）5 //実装予定
            case 0:
                if (randomValue >= 0.95) ret = 5;
                else if (randomValue >= 0.90) ret = 4;
                else if (randomValue >= 0.85) ret = 3;
                else if (randomValue >= 0.75) ret = 2;
                else if (randomValue >= 0.60) ret = 1;
                else ret = 0;           
                break;
            case 1:
                if (randomValue >= 0.90) ret = 4;
                else if (randomValue >= 0.70) ret = 3;
                else if (randomValue >= 0.60) ret = 2;
                else if (randomValue >= 0.50) ret = 1;
                else ret = 0;
                break;
            case 2:
                if (randomValue >= 0.80) ret = 5;
                else if (randomValue >= 0.60) ret = 4;
                else if (randomValue >= 0.40) ret = 3;
                else if (randomValue >= 0.30) ret = 1;
                else ret = 0;
                break;
            case 3:
            case 4:
            case 5:
                if (randomValue >= 0.90) ret = 5;
                else if (randomValue >= 0.80) ret = 4;
                else if (randomValue >= 0.70) ret = 3;
                else if (randomValue >= 0.50) ret = 2;
                else ret = 0;
                break;
        }

        return ret;
    }
}
