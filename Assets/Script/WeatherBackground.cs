using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherBackground : MonoBehaviour
{
    private SpriteRenderer SR;
    [SerializeField] Sprite fine;
    [SerializeField] Sprite cloudy;

    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //����0
        //�ҏ�1
        //�܂�2
        //��J3
        //�\��4
        if (Weather.weatherNo == 0 || Weather.weatherNo == 1)
        {
            SR.sprite = fine;
        }
        else
        {
            SR.sprite = cloudy;
        }

        
    }
}
