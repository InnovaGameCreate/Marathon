using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    //マクロ
    public int jumpNum = 1; //空中でのジャンプ回数

    //変数
    private int jumpCount = 0; //ジャンプ回数
    private float gravity = 0f; //重力変数
    private bool useGravity = false; //重力フラグ
    private bool useJump = false; //ジャンプフラグ

    //仮変数（現段階）
    private float speed = 0.002f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //前進
        this.gameObject.transform.Translate(speed, 0.0f, 0.0f);

        //スピード変更
        if (InputOperation.input.arp)
        {
            speed = 0.001f;
        }
        if (InputOperation.input.srp)
        {
            speed = 0.002f;
        }
        if (InputOperation.input.drp)
        {
            speed = 0.003f;
        }

        //重力オン
        if ((!PlayerMask.gravityLeftRect.trg && !PlayerMask.gravityRightRect.trg) || useJump)
        {
            useGravity = true;
        }
        else
        {
            useGravity = false;
            gravity = 0;
            jumpCount = 0;
        }

        //ジャンプフラグリセット
        if (gravity <= 0) useJump = false;

        //ジャンプ
        if (InputOperation.input.wrp && jumpCount < jumpNum)
        {
            //this.gameObject.transform.Translate(0.0f, 0.05f, 0.0f);
            useJump = true;
            gravity = 0.01f; //重力の設定
            jumpCount++; //空中でのジャンプ回数
        }

        //坂道
        if (PlayerMask.upRect.trg && !useGravity)
        {
            this.gameObject.transform.Translate(0.0f, 0.01f, 0.0f);
        }
        if (!PlayerMask.downRect.trg && !useGravity && !PlayerMask.gravityRightRect.trg)
        {
            this.gameObject.transform.Translate(0.0f, -0.01f, 0.0f);
        }
        
        //重力計算
        if (useGravity)
        {
            gravity -= 0.00002f;
            this.gameObject.transform.Translate(0.0f, gravity, 0.0f);
        }

        //リピート管理
        InputOperation.input.wrp = false;
        InputOperation.input.arp = false;
        InputOperation.input.srp = false;
        InputOperation.input.drp = false;
    }
}
