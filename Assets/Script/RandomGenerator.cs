using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    /*使用目的：このスクリプトをアタッチしたオブジェクトの任意の範囲内で指定した数だけランダムに障害物や回復アイテムを置く*/

    [Tooltip("生成範囲（オブジェクトを中心とする生成半径）")]
    public float generateRange;

    [Tooltip("生成する個数")]
    public float generateNumber;

    [Tooltip("生成するY座標")]
    public float Y;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    [Tooltip("障害物を生成する")]
    public bool obstacleFlag;

    [Tooltip("アイテムを生成する")]
    public bool itemFlag;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);//ランダムにするための宣言

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