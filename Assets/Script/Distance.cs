using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    //�}�N��
    public static float speed = 4f; // m/s��{�X�s�[�h

    //�ϐ�
    public static float slope = 1f; //�⓹�̃X�s�[�h�{��
    public static float dash = 1f; //�v���C���[�̑���{��
    public static float distance = 0f; //�v���C���[���s����
    public static float SPS = 40f; //�����v�Z�����邽�߂̕ϐ�

    //�I�u�W�F�N�g
    public Text distanceLabel;

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        //�����v�Z
        distance += (SPS * slope * dash * Time.deltaTime);

        //�����̕\��
        distanceLabel.text = "�����F" + distance.ToString("N1");
    }
}
