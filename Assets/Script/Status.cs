using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public static int SatietyGauge;//満腹ゲージ90秒で0%になるようにしてください
    public int SatietyGaugeCount;
    public static int WaterGauge;//水分ゲージ90秒で0%になるようにしてください
    public int WaterGaugeCount;
    public static int StaminaGauge;//スタミナゲージ120秒で0になるようにしてください。満腹度と水分が50%以上のときにスタミナが回復する。回復量は40秒で0から100に回復できる程度の速度
    public int StaminaGaugeCount;
    public static int HealthGauge;//体力ゲージ水分ゲージが0のとき,スタミナゲージが0のときそれぞれ毎秒2ずつ減らしてください。重複可能
    public int HealthGaugeCount;
    private float currentTime = 0f;

    void Start()
    {
        SatietyGauge = SatietyGaugeCount;
        WaterGauge = WaterGaugeCount;
        StaminaGauge = StaminaGaugeCount;
        HealthGauge = HealthGaugeCount;
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        SatietyGauge = Mathf.Clamp(SatietyGauge, 0, SatietyGaugeCount);
        WaterGauge = Mathf.Clamp(WaterGauge, 0, WaterGaugeCount);
        StaminaGauge = Mathf.Clamp(StaminaGauge, 0, StaminaGaugeCount);
        HealthGauge = Mathf.Clamp(HealthGauge, 0, HealthGaugeCount);
        if (currentTime >= 1.0f)
        {
            SatietyGauge -= SatietyGaugeCount / 90;
            WaterGauge -= WaterGaugeCount / 90;
            StaminaGauge -= StaminaGaugeCount / 120;
            currentTime = 0;
        }
        //水分、満腹ゲージを90秒で0%になるようにしてください
        //スタミナゲージ120秒で0になるようにしてください
        if (SatietyGauge >= SatietyGaugeCount / 2 && WaterGauge >= WaterGaugeCount / 2)
        {
            StaminaGauge = StaminaGauge + StaminaGaugeCount / 40;
        }
        //満腹度と水分が50%以上のときにスタミナが回復する。
        //回復量は40秒で0から100に回復できる程度の速度
        if (StaminaGauge == 0)
        {
            HealthGauge = HealthGauge - 2;
        }
        //スタミナゲージが０の時毎秒２ずつ現象
        if (WaterGauge == 0)
        {
            HealthGauge = HealthGauge - 2;
        }
        //水分ゲージが０の時毎秒２ずつ現象
        Debug.Log(SatietyGauge);
        Debug.Log(WaterGauge);
        Debug.Log(StaminaGauge);
        Debug.Log(HealthGauge);
    }
}