using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherBackground : MonoBehaviour
{
    private SpriteRenderer SR;
    [SerializeField] Sprite fine;
    [SerializeField] Sprite cloudy;
    [SerializeField] Sprite hot;


    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //âıê∞0
        //ñ“èã1
        //ì‹ÇË2
        //ëÂâJ3
        //ñ\ïó4
        if (Weather.weatherNo == 0)
        {
            SR.sprite = fine;
        }
        else if (Weather.weatherNo == 1)
        {
            SR.sprite = hot;
        }
        else
        {
            SR.sprite = cloudy;
        }

        
    }
}
