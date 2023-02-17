using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public static int SatietyGauge;//満腹ゲージ90秒で0%になるようにしてください
    public static int WaterGauge;//水分ゲージ90秒で0%になるようにしてください
    public static int StaminaGauge;//スタミナゲージ120秒で0になるようにしてください。満腹度と水分が50%以上のときにスタミナが回復する。回復量は40秒で0から100に回復できる程度の速度
    public static int HealthGauge;//体力ゲージ水分ゲージが0のとき,スタミナゲージが0のときそれぞれ毎秒2ずつ減らしてください。重複可能
    private float currentTime = 0f;

    void Start()
    {
        SatietyGauge = 100;
        WaterGauge = 100;
        StaminaGauge = 120;
        HealthGauge = 100;
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        SatietyGauge = Mathf.Clamp(SatietyGauge, 0, 100);
        WaterGauge = Mathf.Clamp(WaterGauge, 0, 100);
        StaminaGauge = Mathf.Clamp(StaminaGauge, 0, 120);
        HealthGauge = Mathf.Clamp(HealthGauge, 0, 100);
        if (currentTime >= 1.0f)
        {
            SatietyGauge -= 100 / 90;
            WaterGauge -= 100 / 90;
            StaminaGauge -= 120 / 120;
            HealthGauge -= 0;
            //水分、満腹ゲージを90秒で0%になるようにしてください
            //スタミナゲージ120秒で0になるようにしてください
            if (SatietyGauge >= 120 / 2 && WaterGauge >= 100 / 2)
            {
                StaminaGauge = StaminaGauge + 120 / 40;
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
            currentTime = 0;
        }
    }
}