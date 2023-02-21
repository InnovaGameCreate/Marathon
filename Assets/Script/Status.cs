using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public static float SatietyGauge;//満腹ゲージ90秒で0%になるようにしてください
    public static float WaterGauge;//水分ゲージ90秒で0%になるようにしてください
    public static float StaminaGauge;//スタミナゲージ120秒で0になるようにしてください。満腹度と水分が50%以上のときにスタミナが回復する。回復量は40秒で0から100に回復できる程度の速度
    public static float HealthGauge;//体力ゲージ水分ゲージが0のとき,スタミナゲージが0のときそれぞれ毎秒2ずつ減らしてください。重複可能
    private float currentTime = 0f;

    public static bool injureflg = false;//怪我状態か否か
    public static int injuretime = 0;//怪我状態である時間
    private int healInjureSecond = 0;//怪我が治るまでにかかる時間のこと

    public static bool coldflg = false;//風邪状態か否か
    private int coldJudgeTime = 0;//5秒で1回風邪状態にするか判定させるための変数
    private int healColdJudgeTime = 0;//5秒で１回風邪状態が治るか判定させる為の変数
    private float stamina_cold = 1.0f;//風邪状態によるスタミナの倍率

    //天気による倍率の変数
    public float satiety_weather = 1;//食料ゲージの倍率
    public float water_weather = 1;//水分の倍率
    public float stamina_weather = 1;//スタミナの倍率
    

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);//ランダムにするための宣言

        SatietyGauge = 100f;
        WaterGauge = 100f;
        StaminaGauge = 100f;
        HealthGauge = 100f;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= 1.0f)
        {
            //天気による倍率を記述
            //食料ゲージについて
            if (Weather.weatherNo == 1)
                satiety_weather = 0.5f;
            else if (Weather.weatherNo == 5)
                satiety_weather = 1.5f;
            else
                satiety_weather = 1.0f;

            //水分について
            if (Weather.weatherNo == 3)
                water_weather = 0.5f;
            else if (Weather.weatherNo == 1)
                water_weather = 1.5f;
            else
                water_weather = 1.0f;

            //スタミナについて
            if (Weather.weatherNo == 2)
                stamina_weather = 0.5f;
            else if(Weather.weatherNo == 4)
                stamina_weather = 1.5f;
            else
                stamina_weather = 1.0f;

            //大雨のとき風邪状態になる確率(5秒で20%)
            if (Weather.weatherNo == 3)
            {          
                if (coldflg == false && coldJudgeTime % 5 == 0)
                {  
                    int random = Random.Range(0, 101);
                   
                    if (random <= 20)
                        coldflg = true;

                    Debug.Log("数値:"); 
                    
                }
            }

            //風邪状態であるときの処理
            if (coldflg == true)
            {
                healColdJudgeTime++;
                if (healColdJudgeTime % 5 == 0)
                {
                    int random = Random.Range(0, 101);
                    if (random <= 50)
                        coldflg = false;

                    
                }
                stamina_cold = 1.2f;
                Debug.Log("風邪です");
            }
            else if (coldflg == false)
            {
                Debug.Log("風邪じゃない");
                coldJudgeTime++;
                stamina_cold = 1.0f;
            }
                


            SatietyGauge -= (100f / 90f) * satiety_weather;
            WaterGauge -= (100f / 90f)* water_weather;
            StaminaGauge -= (100f / 120f)* stamina_weather * stamina_cold;
            HealthGauge -= 0;
            //水分、満腹ゲージを90秒で0%になるようにしてください
            //スタミナゲージ120秒で0になるようにしてください
            if (SatietyGauge >= 100 / 2 && WaterGauge >= 100 / 2)
            {
                StaminaGauge = StaminaGauge + 100f / 40f;
                
            }
            //満腹度と水分が50%以上のときにスタミナが回復する。
            //回復量は40秒で0から100に回復できる程度の速度
            if (StaminaGauge <= 0)
            {
                HealthGauge = HealthGauge - 2;
            }
            //スタミナゲージが０の時毎秒２ずつ現象
            if (WaterGauge <= 0)
            {
                HealthGauge = HealthGauge - 2;
            }
            //水分ゲージが０の時毎秒２ずつ現象

            
            if (injureflg == true)
            {
                HealthGauge = HealthGauge - 1;
                healInjureSecond++;

                if (healInjureSecond == injuretime)
                    injureflg = false;

            }
            //石に触れたら出血状態（10秒間スリップダメージ）



            SatietyGauge = Mathf.Clamp(SatietyGauge, 0, 100);
            WaterGauge = Mathf.Clamp(WaterGauge, 0, 100);
            StaminaGauge = Mathf.Clamp(StaminaGauge, 0, 100);
            HealthGauge = Mathf.Clamp(HealthGauge, 0, 100);

            currentTime = 0;
        }
    }

    
}