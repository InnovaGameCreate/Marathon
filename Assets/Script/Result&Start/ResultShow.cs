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

        text.text = "���s�����F" + Distance.distance.ToString("0") + "m\n" + "���s���ԁF" + Distance.timer.ToString("0") + "�b";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
