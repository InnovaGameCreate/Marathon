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

    public static bool injureflg = false;
    public static int injuretime = 0;
    private int healInjureSecond = 0;
    

    void Start()
    {
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
            SatietyGauge -= 100f / 90f;
            WaterGauge -= 100f / 90f;
            StaminaGauge -= 100f / 120f;
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