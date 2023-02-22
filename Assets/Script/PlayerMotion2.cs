using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotion2 : MonoBehaviour
{
    //�}�N��
    public int jumpNum; //�W�����v������
    public float jumpForce; //�W�����v��
    public Text SlowTimeCounter;//�X���[�_�b�V���̎c�莞�Ԃ�\������e�L�X�g

    //�ϐ�
    private float playerSpeed = 0f; //�v���C���[�ړ��X�s�[�h
    private float walkForce = 100; //�O�i��
    private float cameraOffset; //�J�����Ƃ̑��΋���
    private bool slow = false; //�X���[�_�b�V���t���O
    public static int jumpCount = 0; //�W�����v��
    private float timeCount = 30f; //�X���[�_�b�V���^�C��
    public float staminaPoint = 1.0f;//�X�^�~�i����
    public float warterPoint = 1.0f;//��������

    //tmp
    public static float jumpForceTmp;

    //�R���|�[�l���g�E�I�u�W�F�N�g
    private Rigidbody2D rb;
    [SerializeField] GameObject MainCamera;
    public static PlayerMotion2 ins;

    void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //�擾
        rb = GetComponent<Rigidbody2D>();

        //������
        cameraOffset = MainCamera.gameObject.transform.position.x - this.transform.position.x; //���΋����擾

        //tmp
        jumpForceTmp = jumpForce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(Vector2.right * (playerSpeed - rb.velocity.x) * walkForce);

    }

    void Update()
    {
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
        if (DestoryObject.stomachPain == 1)
        {
            slow = false;
            Distance.dash = 0f;
        }

        //�W�����v
        if (InputOperation.input.wrp && jumpCount < jumpNum && DestoryObject.stomachPain != 1)
        {
            rb.AddForce(Vector2.up * jumpForce); //�W�����v��
            jumpCount++; //�󒆂ł̃W�����v��
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

        SlowTimeCounter.text = "�X���[�c�莞�ԁF" + timeCount.ToString("N1");

        if (this.transform.position.y < 4.0f)
        {
            Status.HealthGauge = 0;
        }

        //�X�s�[�h�l�X�V
        playerSpeed = Distance.speed * Distance.slope * Distance.dash;

        //�J�����ړ�
        Vector3 vec = new Vector3(this.transform.position.x + cameraOffset, 12, -10);
        MainCamera.gameObject.transform.position = vec;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //��
        if (col.gameObject.tag == "Floor")
        {
            Distance.slope = 1f;
            Status.staminaPerSec = 1f;
        }
        if (col.gameObject.tag == "FloorUp")
        {
            Distance.slope = 1.2f;
            Status.staminaPerSec = 1.2f;
        }
        if (col.gameObject.tag == "FloorDown")
        {
            Status.staminaPerSec = 1f;
        }

        //�A�C�e��
        if (col.gameObject.tag == "Heal")
        {
            staminaPoint += 1.0f;//�X�^�~�i��1,0��
        }

        if (col.gameObject.tag == "warter")
        {
            warterPoint += 1.0f;//������1,0��
        }

        jumpCount = 0; //�W�����v�񐔃��Z�b�g
    }

    void OnTriggerStay2D(Collider2D col)
    {
        //����␧��
        if (col.gameObject.tag == "FloorDown")
        {
            rb.AddForce(Vector2.down * (50 - rb.velocity.y) * 50);
        }
    }

    public void PlayerForce(Vector2 vec, float force)
    {
        rb.AddForce(vec * force);
    }
}
