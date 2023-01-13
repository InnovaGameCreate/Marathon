using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int PlayerHP;//体力の実装時に置き換え
    public int Mileage;//走行距離
    private int count;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ObstacleStone")//綴りミスきおつけて
        {
            Destroy(other.gameObject);
            count += 1;
            if(count <= 10)
            {
                Status.HealthGauge -= 1; 
            }
        }
        //if (other.gameObject.tag == "ObstacleRottenOnigiri")//綴りミスきおつけて
        //{
            //Destroy(other.gameObject);
           // count += 1;
            //if(count <= 10)
           //{
                //Speed = 0;
           // }
            //if(count <= 30)
           // {
               // Destroy(Onigiri.tag);
           //}
            //10秒間スピードの変数を０にする＆３０秒間おにぎりのタグを無効化したい（物体自体を向こうでもいい）
       // }
        if (other.gameObject.tag == "ObstacleRunner")//綴りミスきおつけて
        {
            Destroy(other.gameObject);
            Distance.distance = Distance.distance - 1000;//走行距離の変数
        }
    }
}