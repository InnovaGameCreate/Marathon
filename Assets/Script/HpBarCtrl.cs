using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class HpBarCtrl : MonoBehaviour
{
    Slider _slider1;
    Slider _slider2;
    Slider _slider3;
    Slider _slider4;
    void Start()
    {
        // スライダーを取得する
        _slider1 = GameObject.Find("SliderWaterGauge").GetComponent<Slider>();
        _slider2 = GameObject.Find("SliderSatietyGauge").GetComponent<Slider>();
        _slider3 = GameObject.Find("SliderStaminaGauge").GetComponent<Slider>();
        _slider4 = GameObject.Find("SliderHealthGauge").GetComponent<Slider>();

    }
    float _hp1 = 0;
    float _hp2 = 0;
    float _hp3 = 0;
    float _hp4 = 0;

    void Update()
    {
        _hp1 = Status.WaterGauge;
        _hp2 = Status.SatietyGauge;
        _hp3 = Status.StaminaGauge;
        _hp4 = Status.HealthGauge;

        _slider1.value = _hp1 / 100;
        _slider2.value = _hp2 / 100;
        _slider3.value = _hp3 / 120;
        _slider4.value = _hp4 / 100;
    }
}