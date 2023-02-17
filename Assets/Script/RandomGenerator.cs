using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    /*�g�p�ړI�F���̃X�N���v�g���A�^�b�`�����I�u�W�F�N�g�̔C�ӂ͈͓̔��Ŏw�肵�������������_���ɏ�Q����񕜃A�C�e����u��*/

    [Tooltip("�����͈́i�I�u�W�F�N�g�𒆐S�Ƃ��鐶�����a�j")]
    public float generateRange;

    [Tooltip("���������")]
    public float generateNumber;

    [Tooltip("��������Y���W")]
    public float Y;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    [Tooltip("��Q���𐶐�����")]
    public bool obstacleFlag;

    [Tooltip("�A�C�e���𐶐�����")]
    public bool itemFlag;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);//�����_���ɂ��邽�߂̐錾

        if (obstacleFlag == true && itemFlag == false)
        {
            for (int i = 0; i < generateNumber; i++)
            {
                float random = Random.Range(this.transform.position.x - generateRange, this.transform.position.x + generateRange);
                int decideObstacle = Random.Range(0, 3);

                switch (decideObstacle)
                {
                    case 0:
                        Instantiate(obstacle1, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(obstacle2, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(obstacle3, new Vector2(random, Y), Quaternion.identity);
                        break;

                }
            }
        }

        if (obstacleFlag == false && itemFlag == true)
        {
            for (int i = 0; i < generateNumber; i++)
            {
                float random = Random.Range(this.transform.position.x - generateRange, this.transform.position.x + generateRange);
                int itemObstacle = Random.Range(0, 3);

                switch (itemObstacle)
                {
                    case 0:
                        Instantiate(item1, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(item2, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(item3, new Vector2(random, Y), Quaternion.identity);
                        break;

                }
            }
        }

        if (obstacleFlag == true && itemFlag == true)
        {
            for (int i = 0; i < generateNumber; i++)
            {
                float random = Random.Range(this.transform.position.x - generateRange, this.transform.position.x + generateRange);
                int itemObstacle = Random.Range(0, 6);

                switch (itemObstacle)
                {
                    case 0:
                        Instantiate(item1, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 1:
                        Instantiate(item2, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(item3, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(obstacle1, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(obstacle2, new Vector2(random, Y), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(obstacle3, new Vector2(random, Y), Quaternion.identity);
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}