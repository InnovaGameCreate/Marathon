using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    //�}�N��
    public static float speed = 40f; // m/s��{�X�s�[�h

    //�ϐ�
    public static float slope = 1f; //�⓹�̃X�s�[�h�{��
    public static float dash = 1f; //�v���C���[�̑���{��
    public static float distance = 0f; //�v���C���[���s����
    public static float slopeAdd = 0f; //����⎞�̋������Z

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
        distance += (speed * slope * dash * Time.deltaTime + slopeAdd);

        //�����̕\��
        distanceLabel.text = "�����F" + distance.ToString("N1");
    }
}
