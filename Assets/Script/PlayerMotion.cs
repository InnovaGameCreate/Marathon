using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    //�}�N��
    public int jumpNum = 1; //�󒆂ł̃W�����v��

    //�ϐ�
    private int jumpCount = 0; //�W�����v��
    private float gravity = 0f; //�d�͕ϐ�
    private bool useGravity = false; //�d�̓t���O
    private bool useJump = false; //�W�����v�t���O

    //���ϐ��i���i�K�j
    private float speed = 0.002f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�O�i
        this.gameObject.transform.Translate(speed, 0.0f, 0.0f);

        //�X�s�[�h�ύX
        if (InputOperation.input.arp)
        {
            speed = 0.001f;
        }
        if (InputOperation.input.srp)
        {
            speed = 0.002f;
        }
        if (InputOperation.input.drp)
        {
            speed = 0.003f;
        }

        //�d�̓I��
        if ((!PlayerMask.gravityLeftRect.trg && !PlayerMask.gravityRightRect.trg) || useJump)
        {
            useGravity = true;
        }
        else
        {
            useGravity = false;
            gravity = 0;
            jumpCount = 0;
        }

        //�W�����v�t���O���Z�b�g
        if (gravity <= 0) useJump = false;

        //�W�����v
        if (InputOperation.input.wrp && jumpCount < jumpNum)
        {
            //this.gameObject.transform.Translate(0.0f, 0.05f, 0.0f);
            useJump = true;
            gravity = 0.01f; //�d�͂̐ݒ�
            jumpCount++; //�󒆂ł̃W�����v��
        }

        //�⓹
        if (PlayerMask.upRect.trg && !useGravity)
        {
            this.gameObject.transform.Translate(0.0f, 0.01f, 0.0f);
        }
        if (!PlayerMask.downRect.trg && !useGravity && !PlayerMask.gravityRightRect.trg)
        {
            this.gameObject.transform.Translate(0.0f, -0.01f, 0.0f);
        }
        
        //�d�͌v�Z
        if (useGravity)
        {
            gravity -= 0.00002f;
            this.gameObject.transform.Translate(0.0f, gravity, 0.0f);
        }

        //���s�[�g�Ǘ�
        InputOperation.input.wrp = false;
        InputOperation.input.arp = false;
        InputOperation.input.srp = false;
        InputOperation.input.drp = false;
    }
}
