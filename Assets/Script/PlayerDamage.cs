using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int PlayerHP;//�̗͂̎������ɒu������
    public int Mileage;//���s����
    private int count;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObstacleStone")//�Ԃ�~�X��������
        {
            Destroy(other.gameObject);
            count += 1;
            if(count <= 10)
            {
                Status.HealthGauge -= 1; 
            }
        }
        //if (other.gameObject.tag == "ObstacleRottenOnigiri")//�Ԃ�~�X��������
        //{
            //Destroy(other.gameObject);
           // count += 1;
            //if(count <= 10)
           //{
                //Speed = 0;
           // }
            //if(count <= 30)
           // {
               // Destroy(Onigiri.tag);
           //}
            //10�b�ԃX�s�[�h�̕ϐ����O�ɂ��違�R�O�b�Ԃ��ɂ���̃^�O�𖳌����������i���̎��̂��������ł������j
       // }
        if (other.gameObject.tag == "ObstacleRunner")//�Ԃ�~�X��������
        {
            Destroy(other.gameObject);
            Distance.distance = Distance.distance - 1000;//���s�����̕ϐ�
        }
    }
}