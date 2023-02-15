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


    private Vector2 playerPos;

    public static bool CreateStageFlg = false;//trueのときにステージを作成
    private int stageCreateNum = 0;
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

        if ((stageCreateNum +1 % 5 != 0) && (playerPos.x > 30 + 80 * stageCreateNum))
        {
            RandomStageNum = Random.Range(1, 6);
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
            }
            stageCreateNum++;
        }


    }
}
