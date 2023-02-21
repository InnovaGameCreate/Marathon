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

    public static bool injureflg = false;//�����Ԃ��ۂ�
    public static int injuretime = 0;//�����Ԃł��鎞��
    private int healInjureSecond = 0;//���䂪����܂łɂ����鎞�Ԃ̂���

    public static bool coldflg = false;//���׏�Ԃ��ۂ�
    private int coldJudgeTime = 0;//5�b��1�񕗎׏�Ԃɂ��邩���肳���邽�߂̕ϐ�
    private int healColdJudgeTime = 0;//5�b�łP�񕗎׏�Ԃ����邩���肳����ׂ̕ϐ�
    private float stamina_cold = 1.0f;//���׏�Ԃɂ��X�^�~�i�̔{��

    //�V�C�ɂ��{���̕ϐ�
    public float satiety_weather = 1;//�H���Q�[�W�̔{��
    public float water_weather = 1;//�����̔{��
    public float stamina_weather = 1;//�X�^�~�i�̔{��
    

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);//�����_���ɂ��邽�߂̐錾

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
            //�V�C�ɂ��{�����L�q
            //�H���Q�[�W�ɂ���
            if (Weather.weatherNo == 1)
                satiety_weather = 0.5f;
            else if (Weather.weatherNo == 5)
                satiety_weather = 1.5f;
            else
                satiety_weather = 1.0f;

            //�����ɂ���
            if (Weather.weatherNo == 3)
                water_weather = 0.5f;
            else if (Weather.weatherNo == 1)
                water_weather = 1.5f;
            else
                water_weather = 1.0f;

            //�X�^�~�i�ɂ���
            if (Weather.weatherNo == 2)
                stamina_weather = 0.5f;
            else if(Weather.weatherNo == 4)
                stamina_weather = 1.5f;
            else
                stamina_weather = 1.0f;

            //��J�̂Ƃ����׏�ԂɂȂ�m��(5�b��20%)
            if (Weather.weatherNo == 3)
            {          
                if (coldflg == false && coldJudgeTime % 5 == 0)
                {  
                    int random = Random.Range(0, 101);
                   
                    if (random <= 20)
                        coldflg = true;

                    Debug.Log("���l:"); 
                    
                }
            }

            //���׏�Ԃł���Ƃ��̏���
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
                Debug.Log("���ׂł�");
            }
            else if (coldflg == false)
            {
                Debug.Log("���ׂ���Ȃ�");
                coldJudgeTime++;
                stamina_cold = 1.0f;
            }
                


            SatietyGauge -= (100f / 90f) * satiety_weather;
            WaterGauge -= (100f / 90f)* water_weather;
            StaminaGauge -= (100f / 120f)* stamina_weather * stamina_cold;
            HealthGauge -= 0;
            //�����A�����Q�[�W��90�b��0%�ɂȂ�悤�ɂ��Ă�������
            //�X�^�~�i�Q�[�W120�b��0�ɂȂ�悤�ɂ��Ă�������
            if (SatietyGauge >= 100 / 2 && WaterGauge >= 100 / 2)
            {
                StaminaGauge = StaminaGauge + 100f / 40f;
                
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

            
            if (injureflg == true)
            {
                HealthGauge = HealthGauge - 1;
                healInjureSecond++;

                if (healInjureSecond == injuretime)
                    injureflg = false;

            }
            //�΂ɐG�ꂽ��o����ԁi10�b�ԃX���b�v�_���[�W�j



            SatietyGauge = Mathf.Clamp(SatietyGauge, 0, 100);
            WaterGauge = Mathf.Clamp(WaterGauge, 0, 100);
            StaminaGauge = Mathf.Clamp(StaminaGauge, 0, 100);
            HealthGauge = Mathf.Clamp(HealthGauge, 0, 100);

            currentTime = 0;
        }
    }

    
}