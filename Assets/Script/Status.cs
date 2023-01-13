using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public static int SatietyGauge;//�����Q�[�W90�b��0%�ɂȂ�悤�ɂ��Ă�������
    public int SatietyGaugeCount;
    public static int WaterGauge;//�����Q�[�W90�b��0%�ɂȂ�悤�ɂ��Ă�������
    public int WaterGaugeCount;
    public static int StaminaGauge;//�X�^�~�i�Q�[�W120�b��0�ɂȂ�悤�ɂ��Ă��������B�����x�Ɛ�����50%�ȏ�̂Ƃ��ɃX�^�~�i���񕜂���B�񕜗ʂ�40�b��0����100�ɉ񕜂ł�����x�̑��x
    public int StaminaGaugeCount;
    public static int HealthGauge;//�̗̓Q�[�W�����Q�[�W��0�̂Ƃ�,�X�^�~�i�Q�[�W��0�̂Ƃ����ꂼ�ꖈ�b2�����炵�Ă��������B�d���\
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
        //�����A�����Q�[�W��90�b��0%�ɂȂ�悤�ɂ��Ă�������
        //�X�^�~�i�Q�[�W120�b��0�ɂȂ�悤�ɂ��Ă�������
        if (SatietyGauge >= SatietyGaugeCount / 2 && WaterGauge >= WaterGaugeCount / 2)
        {
            StaminaGauge = StaminaGauge + StaminaGaugeCount / 40;
        }
        //�����x�Ɛ�����50%�ȏ�̂Ƃ��ɃX�^�~�i���񕜂���B
        //�񕜗ʂ�40�b��0����100�ɉ񕜂ł�����x�̑��x
        if (StaminaGauge == 0)
        {
            HealthGauge = HealthGauge - 2;
        }
        //�X�^�~�i�Q�[�W���O�̎����b�Q������
        if (WaterGauge == 0)
        {
            HealthGauge = HealthGauge - 2;
        }
        //�����Q�[�W���O�̎����b�Q������
        Debug.Log(SatietyGauge);
        Debug.Log(WaterGauge);
        Debug.Log(StaminaGauge);
        Debug.Log(HealthGauge);
    }
}