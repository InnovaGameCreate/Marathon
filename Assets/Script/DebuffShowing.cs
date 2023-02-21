using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffShowing : MonoBehaviour
{
    private SpriteRenderer SR1;
    private SpriteRenderer SR2;
    private SpriteRenderer SR3;

    [SerializeField] Sprite blood;
    [SerializeField] Sprite stomachPain;
    [SerializeField] Sprite cold;

    [SerializeField] GameObject DebuffIcon1;
    [SerializeField] GameObject DebuffIcon2;
    [SerializeField] GameObject DebuffIcon3;

    private GameObject player;

    private int DebuffNum = 0;//現在なっている状態異常の数
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        SR1 = DebuffIcon1.GetComponent<SpriteRenderer>();
        SR2 = DebuffIcon2.GetComponent<SpriteRenderer>();
        SR3 = DebuffIcon3.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //各状態異常のときにstatic変数に１入れる。
        //DebuffNum = Statas.  + Statas.  + DestroyObject.

        if (DebuffNum == 1)
        {
            DebuffIcon1.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2.0f);
            //どの状態異常になっているのか検知して対応するsprite入れる


            DebuffIcon2.SetActive(false);
            DebuffIcon3.SetActive(false);

        }
        else if (DebuffNum == 2)
        {
            DebuffIcon1.transform.position = new Vector2(player.transform.position.x - 0.3f, player.transform.position.y + 2.0f);
            DebuffIcon2.transform.position = new Vector2(player.transform.position.x + 0.7f, player.transform.position.y + 2.0f);
            //どの状態異常になっているのか検知して対応するsprite入れる


            DebuffIcon3.SetActive(false);
        }
        else if (DebuffNum == 3)
        {
            DebuffIcon1.transform.position = new Vector2(player.transform.position.x - 0.8f, player.transform.position.y + 2.0f);
            DebuffIcon2.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2.0f);
            DebuffIcon3.transform.position = new Vector2(player.transform.position.x + 0.9f, player.transform.position.y + 2.0f);

            SR1.sprite = blood;
            SR2.sprite = stomachPain;
            SR3.sprite = cold;
        }
        else if (DebuffNum == 0)
        {
            DebuffIcon1.SetActive(false);
            DebuffIcon2.SetActive(false);
            DebuffIcon3.SetActive(false);
        }
    }
}
