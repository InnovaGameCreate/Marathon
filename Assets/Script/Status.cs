using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public static float SatietyGauge;//�����Q�[�W90�b��0%�ɂȂ�悤�ɂ��Ă�������
    public static float WaterGauge;//�����Q�[�W90�b��0%�ɂȂ�悤�ɂ��Ă�������
    public static float StaminaGauge;//�X�^�~�i�Q�[�W120�b��0�ɂȂ�悤�ɂ��Ă��������B�����x�Ɛ�����50%�ȏ�̂Ƃ��ɃX�^�~�i���񕜂���B�񕜗ʂ�40�b��0����100�ɉ񕜂ł�����x�̑��x
    public static float HealthGauge;//�̗̓Q�[�W�����Q�[�W��0�̂Ƃ�,�X�^�~�i�Q�[�W��0�̂Ƃ����ꂼ�ꖈ�b2�����炵�Ă��������B�d���\
    private float currentTime = 0f;

    void Start()
    {
        SatietyGauge = 100;
        WaterGauge = 100;
        StaminaGauge = 100;
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
            StaminaGauge -= 100 / 120;
            HealthGauge -= 0;
            //�����A�����Q�[�W��90�b��0%�ɂȂ�悤�ɂ��Ă�������
            //�X�^�~�i�Q�[�W120�b��0�ɂȂ�悤�ɂ��Ă�������
            if (SatietyGauge >= 100 / 2 && WaterGauge >= 100 / 2)
            {
                StaminaGauge = StaminaGauge + 100 / 40;
            }
            //�����x�Ɛ�����50%�ȏ�̂Ƃ��ɃX�^�~�i���񕜂���B
            //�񕜗ʂ�40�b��0����100�ɉ񕜂ł�����x�̑��x
            if (StaminaGauge <= 0)
            {
                HealthGauge = HealthGauge - 2;
            }
            //�X�^�~�i�Q�[�W���O�̎����b�Q������
            if (WaterGauge <= 0)
            {
                HealthGauge = HealthGauge - 2;
            }
            //�����Q�[�W���O�̎����b�Q������
            if (PlayerDamage.count == 1)
            {
                HealthGauge = HealthGauge - 1;
            }
            currentTime = 0;
        }
    }
}