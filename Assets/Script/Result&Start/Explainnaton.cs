using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explainnaton : MonoBehaviour
{
    [SerializeField] GameObject explain;
    [SerializeField] Sprite explain1;
    [SerializeField] Sprite explain2;
    [SerializeField] Sprite explain3;
    [SerializeField] Sprite explain4;

    private Image image;
    private int pageNum;//現在開いているページ番号
    // Start is called before the first frame update
    void Start()
    {
        image = explain.GetComponent<Image>();
        explain.SetActive(false);
        pageNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(pageNum >= 2)
            pageNum--;
            ChangeExplain();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(pageNum <= 3)
            pageNum++;
            ChangeExplain();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ExitExplain();
        }


    }

    void ChangeExplain()
    {
        switch (pageNum)
        {
            case 1:
                image.sprite = explain1;
                break;
            case 2:
                image.sprite = explain2;
                break;
            case 3:
                image.sprite = explain3;
                break;
            case 4:
                image.sprite = explain4;
                break;
            default:
                break;
        }
    }


    void ExitExplain()
    {
        pageNum = 1;
        explain.SetActive(false);
    }
}
