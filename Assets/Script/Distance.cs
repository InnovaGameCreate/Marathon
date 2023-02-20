using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Distance : MonoBehaviour
{
    //�}�N��
    public static float speed = 4f; // m/s��{�X�s�[�h

    //�ϐ�
    public static float slope = 1f; //�⓹�̃X�s�[�h�{��
    public static float dash = 1f; //�v���C���[�̑���{��
    public static float distance;//�v���C���[���s����
    public static float SPS = 40f; //�����v�Z�����邽�߂̕ϐ�

    public static float timer;//�Q�[���I�[�o�[�ɂȂ�܂łǂ�قǂ̎��ԑ�������

    //�I�u�W�F�N�g
    public Text timeLabel;
    public Text distanceLabel;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        distance = 0f;
        timer = 0f;
    }



    // Update is called once per frame
    void Update()
    {
        //�����v�Z
        distance += (SPS * slope * dash * Time.deltaTime);

        //���Ԍv�Z
        timer += Time.deltaTime;

        //�����̕\��
        distanceLabel.text = "�����F" + distance.ToString("N1") + "m";

        //���Ԃ̕\��
        timeLabel.text = "�o�ߎ��ԁF" + timer.ToString("F2");

        //Debug.Log(SPS);
    }

    
}
