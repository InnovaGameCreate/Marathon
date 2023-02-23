using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRoadMove : MonoBehaviour
{
    [SerializeField] GameObject runner;
    [SerializeField] GameObject BackGround;
    [SerializeField] GameObject Rain;
    [SerializeField] GameObject Snow;
    [SerializeField] GameObject Wind;

    [SerializeField] Sprite fine;
    [SerializeField] Sprite cloudy;
    [SerializeField] Sprite hot;

    private int weatherNo;
    private SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        runner.transform.position = new Vector2(-16.0f, 0);
        SR = BackGround.GetComponent<SpriteRenderer>();

        weatherNo = Random.Range(0, 8);
        if (weatherNo == 3)
            Rain.SetActive(true);
        else if (weatherNo != 3)
            Rain.SetActive(false);

        if (weatherNo == 4)
            Wind.SetActive(true);
        else if (weatherNo != 4)
            Wind.SetActive(false);

        if (weatherNo == 5)
            Snow.SetActive(true);
        else if (weatherNo != 5)
            Snow.SetActive(false);

        if (weatherNo == 0 || weatherNo == 6 || weatherNo == 7)
            SR.sprite = fine;
        else if(weatherNo == 1)
            SR.sprite = hot;
        else
            SR.sprite = cloudy;


    }

    // Update is called once per frame
    void Update()
    {
       runner.gameObject.transform.Translate(0.1f, 0.0f, 0.0f);
        if (runner.transform.position.x >= 43.0f)
        {
            runner.transform.position = new Vector2(-16.0f , 0);
        }
    }
}
