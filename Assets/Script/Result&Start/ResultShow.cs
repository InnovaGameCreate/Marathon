using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultShow : MonoBehaviour
{
    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        //Distance = GameObject.Find("DistanceMeasure");
        //distanceCs = Distance.GetComponent <Distance> ();

        text.text = "走行距離：" + Distance.distance.ToString("0") + "m\n" + "走行時間：" + Distance.timer.ToString("0") + "秒";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
