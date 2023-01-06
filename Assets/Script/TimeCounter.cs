using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //�ϐ�
    private float timeCount = 0f; //�^�C���J�E���g

    //�I�u�W�F�N�g
    public Text timeCountLabel; //�^�C���J�E���g�\��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime; //���Ԍv��
        timeCountLabel.text = "�^�C���F" + timeCount.ToString("N2"); //UI
    }
}
