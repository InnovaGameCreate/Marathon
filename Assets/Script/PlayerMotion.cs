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
    public int jumpCount = 0; //�W�����v�񐔌v��
    public float velocity = 0f; //�~�����x
    private float timeCount = 30f; //�X���[�_�b�V���̃^�C���J�E���g
    public Text SlowTimeCounter;//�X���[�_�b�V���̎c�莞�Ԃ�\������e�L�X�g
    public static float stamina = 1.0f; //�X�^�~�i�����
    public float staminaPoint = 1.0f;//�X�^�~�i����
    public float warterPoint = 1.0f;//��������
    private int dashNum = 1; //�_�b�V���ԍ�
    private bool slowDash = true; //�X���[�_�b�V���t���O
    private bool quickDash = true; //�N�C�b�N�_�b�V���t���O
    private  bool grav = false; //�d�̓t���O

    public static float windDebuff;

    [SerializeField] GameObject MainCamera;


    // Start is called before the first frame update
    void Start()
    {
        windDebuff = 1.0f;
    }

    void FixedUpdate()
    {
        //�d��
        if (grav)
        {
            velocity -= acceleration * Time.deltaTime;
            this.gameObject.transform.Translate(0.0f, velocity, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Weather.weatherNo == 4)
        {
            windDebuff = 0.8f;
        }
        else
        {
            windDebuff = 1.0f;
        }
        Debug.Log(windDebuff);
        //�O�i
        this.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * DestoryObject.energyCount * windDebuff* Time.deltaTime, 0.0f, 0.0f);
        MainCamera.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * DestoryObject.energyCount * windDebuff * Time.deltaTime, 0.0f, 0.0f);

        //�_�b�V���؂�ւ�
        if (InputOperation.input.arp && slowDash && DestoryObject.energyflg != true) dashNum = 0;
        if (InputOperation.input.srp) dashNum = 1;
        if (InputOperation.input.drp && quickDash) dashNum = 2;

        //��������
        if (slowDash)
        {
            if (timeCount < 0)
            {
                slowDash = false;
                dashNum = 1;
            }
        }

        if (quickDash == true)
        {
            if (Status.StaminaGauge <= 0)
            {
                quickDash = false;
                dashNum = 1;
            }
        }
        else
        {
            if (Status.StaminaGauge > 0)
            {
                quickDash = true;
                dashNum = 1;
            }
        }

        //�_�b�V��
        switch (dashNum)
        {
            case 0:
                timeCount -= Time.deltaTime; //���Ԍv��
                Distance.dash = 0.5f;
                Status.staminaPerSec = 0;
                break;
            case 1:
                Distance.dash = 1f;
                Status.staminaPerSec = Distance.dash * Distance.slope;
                break;
            case 2:
                Distance.dash = 1.5f;
                Status.staminaPerSec = Distance.dash * Distance.slope;
                break;
        }

        if (DestoryObject.stomachPain == 1)
        {
            Distance.dash = 0f;
        }

        //�v���C���[�㉺�ړ�
        switch (PlayerMask.playerMove)
        {
            case 0:
                grav = true;
                //Debug.Log("gravity");
                //velocity -= acceleration * Time.deltaTime;
                //this.gameObject.transform.Translate(0.0f, velocity, 0.0f); 
                //jumpCount = 1;
                break;
            case 1:
                grav = false;
                velocity = 0;
                jumpCount = 0;
                Distance.slope = 1f;
                break;
            case 2:
                grav = false;
                //Debug.Log("up");
                this.gameObject.transform.Translate(0.0f, 0.15f, 0.0f);//0.15
                Distance.slope = 1.2f;
                break;
            case 3:
                grav = false;
                //Debug.Log("down");
                this.gameObject.transform.Translate(0.0f, -0.01f, 0.0f);
                break;
        }

        //�W�����v
        if (InputOperation.input.wrp && jumpCount < jumpNum && DestoryObject.stomachPain != 1)
        {
            velocity = setVelocity;
            this.gameObject.transform.Translate(0.0f, 1f, 0.0f);
            PlayerMask.playerMove = 0;
            jumpCount++; //�󒆂ł̃W�����v��
        }

        //���s�[�g�Ǘ�
        InputOperation.input.wrp = false;
        InputOperation.input.arp = false;
        InputOperation.input.srp = false;
        InputOperation.input.drp = false;

        SlowTimeCounter.text = "�X���[�c�莞�ԁF" + timeCount.ToString("N1");

        if (this.transform.position.y < 5.0f)
        {
            Status.HealthGauge = 0;
        }

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
