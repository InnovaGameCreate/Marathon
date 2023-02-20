using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int Mileage;//走行距離
    public static int count;
    public static Rigidbody2D col;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.tag == "ObstacleStone")
      {
             StartCoroutine("Damage");
            Destroy(other.gameObject);
      }

      if (other.gameObject.tag == "ObstacleRottenOnigiri")
      {
            StartCoroutine("STOP");
            StartCoroutine("NOEAT");
            Destroy(other.gameObject);
      }
       
      if (other.gameObject.tag == "ObstacleRunner")//綴りミスきおつけて
      {
            Distance.distance = Distance.distance - 1000;//走行距離の変数
            Destroy(other.gameObject);
      }

      IEnumerator Damage()
      {
            count = 1;
            yield return new WaitForSeconds(10.0f);
            count = 0;
      }

      IEnumerator STOP()
      {
            count = 2;
            yield return new WaitForSeconds(10.0f);
            count = 0;
      }
        
      IEnumerator NOEAT()
      {
            count = 3;
            yield return new WaitForSeconds(30.0f);
            count = 0;
      }
   }
}
