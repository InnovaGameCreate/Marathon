using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public static int SatietyGauge;//満腹ゲージ90秒で0%になるようにしてください
    public static int MoistureGauge;//水分ゲージ90秒で0%になるようにしてください
    public static int StaminaGauge;//スタミナゲージ120秒で0になるようにしてください。満腹度と水分が50%以上のときにスタミナが回復する。回復量は40秒で0から100に回復できる程度の速度
    public static int HealthGauge;//体力ゲージ水分ゲージが0のとき,スタミナゲージが0のときそれぞれ毎秒2ずつ減らしてください。重複可能\
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
