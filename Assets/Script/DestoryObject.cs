using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
    public GameObject player;
    private PlayerMotion playerMotionCs;

    public static  int stomachPain = 0;//0:���Ƀi�V , 1:�����Ȃ���� , 2:�H�ׂ��Ȃ����
    private float healStomachPainTime = 0;//���ɂ�����܂ŕK�v�Ȏ���

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMotionCs = player.GetComponent<PlayerMotion>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stomachPain);

        if (stomachPain != 0 && healStomachPainTime > 0)
        {
            healStomachPainTime -= Time.deltaTime;

            if (stomachPain == 1 && healStomachPainTime <= 25f)
            {
                Distance.dash = 1.0f;
                stomachPain = 2;
            }

            if (healStomachPainTime <= 0f)
                stomachPain = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        Debug.Log("atatta");
        if (col.gameObject.tag == "JumpRamp")
        {
            playerMotionCs.velocity = playerMotionCs.setVelocity * 1.1f;
            player.gameObject.transform.Translate(0.0f, 0.2f, 0.0f);
            PlayerMask.playerMove = 0;
            playerMotionCs.jumpCount++; //�󒆂ł̃W�����v��
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Water")
        {
            Status.WaterGauge = 100;
            Destroy(col.gameObject);
        }

        //��Q���֌W
        if (col.gameObject.tag == "ObstacleStone")
        {
            Status.injuretime += 10;
            Status.injureflg = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "ObstacleRottenOnigiri")
        {
            stomachPain = 1;
            healStomachPainTime = 30;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "ObstacleRunner")//�Ԃ�~�X��������
        {
            Distance.distance -= 1000;//���s�����̕ϐ�
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Riceball")
        {
            if(stomachPain == 0)
            Status.SatietyGauge = 100;

            Destroy(col.gameObject);
        }
    }    
}
    
