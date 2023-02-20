using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotion : MonoBehaviour
{
    //�}�N��
    public int jumpNum = 1; //�󒆂ł̃W�����v��
    public float acceleration = 0.98f; //�����x
    public float setVelocity = 0f; //�W�����v�����x

    //�ϐ�
    private int jumpCount = 0; //�W�����v�񐔌v��
    private float velocity = 0f; //�~�����x
    private float timeCount = 30f; //�X���[�_�b�V���̃^�C���J�E���g
    private bool slow = false; //�X���[�_�b�V���t���O
    public float staminaPoint = 1.0f;//�X�^�~�i����
    public float warterPoint = 1.0f;//��������

    [SerializeField] GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //�O�i
        this.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * Time.deltaTime, 0.0f, 0.0f);
        MainCamera.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * Time.deltaTime, 0.0f, 0.0f);

        //�X�s�[�h�ύX
        if (InputOperation.input.arp && timeCount >= 0)
        {
            slow = true;
            Distance.dash = 0.5f;
        }
        if (InputOperation.input.srp)
        {
            slow = false;
            Distance.dash = 1f;
        }
        if (InputOperation.input.drp)
        {
            slow = false;
            Distance.dash = 1.5f;
        }

        //�W�����v
        if (InputOperation.input.wrp && jumpCount < jumpNum)
        {
            velocity = setVelocity;
            this.gameObject.transform.Translate(0.0f, 0.1f, 0.0f);
            PlayerMask.playerMove = 0;
            jumpCount++; //�󒆂ł̃W�����v��
        }

        //�v���C���[�㉺�ړ�
        switch (PlayerMask.playerMove)
        {
            case 0:
                //Debug.Log("gravity");
                velocity -= acceleration * Time.deltaTime;
                this.gameObject.transform.Translate(0.0f, velocity, 0.0f); 
                //jumpCount = 1;
                break;
            case 1:
                velocity = 0;
                jumpCount = 0;
                Distance.slope = 1f;
                Status.staminaPerSec = 1f;
                break;
            case 2:
                //Debug.Log("up");
                this.gameObject.transform.Translate(0.0f, 0.15f, 0.0f);//0.15
                Distance.slope = 1.2f;
                Status.staminaPerSec = 1.2f;
                break;
            case 3:
                //Debug.Log("down");
                this.gameObject.transform.Translate(0.0f, -0.01f, 0.0f);
                Status.staminaPerSec = 1f;
                break;
        }

        //�X���[�_�b�V���̃^�C���J�E���g
        if (slow)
        {
            //���Ԍv��
            timeCount -= Time.deltaTime;

            //���Ԃ��g���؂�
            if (timeCount < 0)
            {
                slow = false;
                Distance.dash = 1f;
            }
        }

        //���x�����̌v�Z
        Status.staminaPerSec = Distance.dash * Distance.slope;

        //���s�[�g�Ǘ�
        InputOperation.input.wrp = false;
        InputOperation.input.arp = false;
        InputOperation.input.srp = false;
        InputOperation.input.drp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.tag == "Heal")
        {
            staminaPoint += 1.0f;//�X�^�~�i��1,0��
        }

        if (other.gameObject.tag == "warter")
        {
           warterPoint += 1.0f;//������1,0��
        }
    }

        }
