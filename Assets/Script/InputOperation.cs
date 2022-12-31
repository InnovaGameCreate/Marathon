using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOperation : MonoBehaviour
{
    //キーボード入力を管理する構造体
    public struct InputFLG
    {
        public bool w;
        public bool wrp; //リピートフラグ
        public bool a;
        public bool arp;
        public bool s;
        public bool srp;
        public bool d;
        public bool drp;
    }

    public static InputFLG input; //キーボード入力

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //キーボードを押したとき
        if (Input.GetKeyDown(KeyCode.W))
        {
            input.w = true;
            input.wrp = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            input.a = true;
            input.arp = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            input.s = true;
            input.srp = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            input.d = true;
            input.drp = true;
        }


        //キーボードを離したとき
        if (Input.GetKeyUp(KeyCode.W))
        {
            input.w = false;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            input.a = false;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            input.s = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            input.d = false;
        }
    }
}
