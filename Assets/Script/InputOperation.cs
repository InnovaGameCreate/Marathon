using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOperation : MonoBehaviour
{
    //�L�[�{�[�h���͂��Ǘ�����\����
    public struct InputFLG
    {
        public bool w;
        public bool wrp; //���s�[�g�t���O
        public bool a;
        public bool arp;
        public bool s;
        public bool srp;
        public bool d;
        public bool drp;
    }

    public static InputFLG input; //�L�[�{�[�h����

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�L�[�{�[�h���������Ƃ�
        if (Input.GetKeyDown(KeyCode.W))
        {
            input.w = true;
            input.wrp = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            input.a = true;
            input.arp = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            input.s = true;
            input.srp = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            input.d = true;
            input.drp = true;
        }


        //�L�[�{�[�h�𗣂����Ƃ�
        if (Input.GetKeyUp(KeyCode.W))
        {
            input.w = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            input.a = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            input.s = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            input.d = false;
        }
    }
}
