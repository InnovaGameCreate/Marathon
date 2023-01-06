using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int PlayerHP;//体力の実装時に置き換え
    public int Mileage;//走行距離
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("LossHealth");
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObstacleStone")//綴りミスきおつけて
        {
            //Destroy(other.gameObject);
            //int a;
            // double x = Time.deltaTime;//変換式
       //IEnumerator LossHealth()
         //{
            // PlayerHP = PlayerHP - a;
            // yield return new WaitForSeconds(10.0f);
            // PlayerHP = PlayerHP - 0;１０秒間体力を減らす
            //頭上に画像出現
          //}
            
        }

        if (other.gameObject.tag == "ObstacleRottenOnigiri")//綴りミスきおつけて
        {
            Destroy(other.gameObject);
            //10秒間スピードの変数を０にする＆３０秒間おにぎりのタグを無効化したい（物体自体を向こうでもいい）
        }

        if (other.gameObject.tag == "ObstacleRunner")//綴りミスきおつけて
        {
            Destroy(other.gameObject);
            Mileage = Mileage - 1000;//走行距離の変数
        }
    }
}