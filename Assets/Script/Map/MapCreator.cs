using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public GameObject player;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;
    public GameObject stage5;
    public GameObject stage6;
    public GameObject stage7;
    public GameObject stage8;
    public GameObject stage9;
    public GameObject stage10;

    private Vector2 playerPos;

    public static bool CreateStageFlg = false;//trueのときにステージを作成
    public int stageCreateNum = 0;
    private int RandomStageNum;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);//ランダムにするための宣言

    }

    // Update is called once per frame
    void Update()
    {
        playerPos.x = player.transform.position.x;

        if (playerPos.x > 30 + 80 * stageCreateNum)
        {
            RandomStageNum = Random.Range(1,11);
            if (stageCreateNum % 5 != 0)
            {
                switch (RandomStageNum)
                {
                    case 1:
                        Instantiate(stage1, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(stage2, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(stage3, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(stage4, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 5:
                        Instantiate(stage5, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 6:
                        Instantiate(stage6, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 7:
                        Instantiate(stage7, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 8:
                        Instantiate(stage8, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 9:
                        Instantiate(stage9, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                    case 10:
                        Instantiate(stage10, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
                        break;
                }
            }
            else if (stageCreateNum % 5 == 0)
            {
                Instantiate(stage3, new Vector2(80 + 80 * stageCreateNum, 0), Quaternion.identity);
            }
           
            stageCreateNum++;
        }


    }
}
