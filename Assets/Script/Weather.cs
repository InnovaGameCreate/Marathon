using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    //�}�N��
    public int CycleTime = 60; //�����^�C��

    //�ϐ�
    public static int weatherNo = 0; //�V�CNo
    private float timeCount = 0f; //�^�C���J�E���g
    private float randomValue; //�m���l

    private GameObject player;
    public GameObject Rain;
    //public GameObject Snow;
    //public GameObject Wind;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //�v��
        timeCount += Time.deltaTime;

        if (timeCount >= CycleTime)
        {
            //�J�E���g���Z�b�g
            timeCount = 0;

            //�V�C�̌v�Z
            weatherNo = WeatherProbability(weatherNo);

            if (weatherNo == 3)
                Rain.SetActive(true);
            else if(weatherNo != 3)
                Rain.SetActive(false);

            Debug.Log(weatherNo);
        }
    }

    int WeatherProbability(int no)
    {
        //�Ԃ�l
        int ret = 0;

        //�����_���l
        randomValue = Random.value;

        //�V�C�̌���
        switch (no)
        {
            //����0
            //�ҏ�1
            //�܂�2
            //��J3
            //�\��4
            case 0:
                if (randomValue >= 0.95) ret = 4;
                else if (randomValue >= 0.90) ret = 3;
                else if (randomValue >= 0.80) ret = 2;
                else if (randomValue >= 0.70) ret = 1;
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
                if (randomValue >= 0.70) ret = 4;
                else if (randomValue >= 0.40) ret = 3;
                else if (randomValue >= 0.30) ret = 1;
                else ret = 0;
                break;
            case 3:
            case 4:
                if (randomValue >= 0.90) ret = 4;
                else if (randomValue >= 0.80) ret = 3;
                else if (randomValue >= 0.70) ret = 1;
                else ret = 0;
                break;
        }

        return ret;
    }
}
