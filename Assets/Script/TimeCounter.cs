using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    //変数
    private float timeCount = 0f; //タイムカウント

    //オブジェクト
    public Text timeCountLabel; //タイムカウント表示

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime; //時間計測
        timeCountLabel.text = "タイム：" + timeCount.ToString("N2"); //UI
    }
}
