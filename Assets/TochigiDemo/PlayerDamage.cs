using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int PlayerHP;//�̗͂̎������ɒu������
    public int Mileage;//���s����
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("LossHealth");
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObstacleStone")//�Ԃ�~�X��������
        {
            //Destroy(other.gameObject);
            //int a;
            // double x = Time.deltaTime;//�ϊ���
       //IEnumerator LossHealth()
         //{
            // PlayerHP = PlayerHP - a;
            // yield return new WaitForSeconds(10.0f);
            // PlayerHP = PlayerHP - 0;�P�O�b�ԑ̗͂����炷
            //����ɉ摜�o��
          //}
            
        }

        if (other.gameObject.tag == "ObstacleRottenOnigiri")//�Ԃ�~�X��������
        {
            Destroy(other.gameObject);
            //10�b�ԃX�s�[�h�̕ϐ����O�ɂ��違�R�O�b�Ԃ��ɂ���̃^�O�𖳌����������i���̎��̂��������ł������j
        }

        if (other.gameObject.tag == "ObstacleRunner")//�Ԃ�~�X��������
        {
            Destroy(other.gameObject);
            Mileage = Mileage - 1000;//���s�����̕ϐ�
        }
    }
}