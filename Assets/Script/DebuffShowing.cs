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
    [SerializeField] GameObject DebuffIcon4;
    [SerializeField] GameObject DebuffIcon5;

    private GameObject player;

    private int DebuffNum = 0;//現在なっている状態異常の数
    private int injure = 0;
    private int stomach = 0;
    private int catchCold = 0;
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
        if (Status.injureflg == true)
            injure = 1;
        else
            injure = 0;

        if (DestoryObject.stomachPain != 0)
            stomach = 1;
        else
            stomach = 0;

        if (Status.coldflg == true)
            catchCold = 1;
        else
            catchCold = 0;


        //今なっている状態異常の数を検知(最大4)
        DebuffNum = injure + stomach + catchCold;

        //状態異常になっている数に応じてアイコンの場所を変更＆アイコンの画像を変える
        if (DebuffNum == 1)
        {
            DebuffIcon1.SetActive(true);

            DebuffIcon1.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2.0f);

            //どの状態異常になっているのか検知して対応するsprite入れる
            if(injure == 1)
                SR1.sprite = blood;

            else if(stomach == 1)
                SR1.sprite = stomachPain;

            else if(catchCold == 1)
                SR1.sprite = cold;

            DebuffIcon2.SetActive(false);
            DebuffIcon3.SetActive(false);
        }
        else if (DebuffNum == 2)
        {
            DebuffIcon1.SetActive(true);
            DebuffIcon2.SetActive(true);


            DebuffIcon1.transform.position = new Vector2(player.transform.position.x - 0.3f, player.transform.position.y + 2.0f);
            DebuffIcon2.transform.position = new Vector2(player.transform.position.x + 0.7f, player.transform.position.y + 2.0f);

            //どの状態異常になっているのか検知して対応するsprite入れる
            if (injure == 1 && stomach == 1)
            {
                SR1.sprite = blood;
                SR2.sprite = stomachPain;
            }
            else if (injure == 1 && catchCold == 1)
            {
                SR1.sprite = blood;
                SR2.sprite = cold;
            }
            else if (stomach == 1 && catchCold == 1)
            {
                SR1.sprite = stomachPain;
                SR2.sprite = cold;
            }

            DebuffIcon3.SetActive(false);
        }
        else if (DebuffNum == 3)
        {
            DebuffIcon1.SetActive(true);
            DebuffIcon2.SetActive(true);
            DebuffIcon3.SetActive(true);

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

        //エネルギッシュの時に目に炎を表示させる
        if (DestoryObject.energyflg == true)
        {
            DebuffIcon4.SetActive(true);
            DebuffIcon5.SetActive(true);
        }
        else if (DestoryObject.energyflg == false)
        {
            DebuffIcon4.SetActive(false);
            DebuffIcon5.SetActive(false);
        }
    }
}
