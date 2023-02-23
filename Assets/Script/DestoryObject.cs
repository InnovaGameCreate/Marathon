using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
    public GameObject player;
    private PlayerMotion playerMotionCs;

    [SerializeField] AudioSource AS;
    public AudioClip get;

    public static  int stomachPain;//0:���Ƀi�V , 1:�����Ȃ���� , 2:�H�ׂ��Ȃ����
    private float healStomachPainTime;//���ɂ�����܂ŕK�v�Ȏ���

    public static bool energyflg;
    public static int energyCount;
    private float energyTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMotionCs = player.GetComponent<PlayerMotion>();
        AS = GetComponent<AudioSource>();

        stomachPain = 0;
        healStomachPainTime = 0;

        energyflg = false;
        energyCount = 1;
        energyTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //���ɂ̏����i5�b�������Ȃ�,20�b���ɂ���H�ׂ��Ȃ��j�������Ă���
        if (stomachPain != 0 && healStomachPainTime > 0)
        {
            healStomachPainTime -= Time.deltaTime;

            if (stomachPain == 1 && healStomachPainTime <= 15f)
            {
                Distance.dash = 1.0f;
                stomachPain = 2;
            }

            if (healStomachPainTime <= 0f)
                stomachPain = 0;
        }

        //�G�i�W�[��Ԃ��������邽�߂̃^�C�}�[
        if (energyflg == true && energyTime > 0)
        {
            energyTime -= Time.deltaTime;

            if (energyTime <= 0f)
            {
                energyCount = 1;
                energyflg = false;
            }
                

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("atatta");
        AS.PlayOneShot(get);

        if (col.gameObject.CompareTag("JumpRamp"))
        {
            playerMotionCs.velocity = playerMotionCs.setVelocity * 1.2f;
            player.gameObject.transform.Translate(0.0f, 0.2f, 0.0f);
            PlayerMask.playerMove = 0;
            playerMotionCs.jumpCount++; //�󒆂ł̃W�����v��
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Water"))
        {
            Status.WaterGauge = 100;
            Destroy(col.gameObject);
        }

        //��Q���֌W
        if (col.gameObject.CompareTag("ObstacleStone"))
        {
            Status.injuretime += 10;
            Status.injureflg = true;
            Destroy(col.gameObject);
        }
        
        if (col.gameObject.CompareTag("ObstacleRottenOnigiri"))
        {
            stomachPain = 1;
            healStomachPainTime = 20;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("ObstacleRunner"))//�Ԃ�~�X��������
        {
            Distance.distance -= 1000;//���s�����̕ϐ�
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Riceball"))
        {
            if(stomachPain == 0)
            Status.SatietyGauge = 100;

            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("EnergyDrink"))
        {
            Status.StaminaGauge += 10;
            energyCount = 2;
            energyTime += 10;
            energyflg = true;

            Destroy(col.gameObject);
        }
    }    
}
    
