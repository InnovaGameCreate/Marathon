using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    public int frame;//速さ（FPS）
    public int offset;//何個めのフレームから始めるか
    public bool loop;
    public bool playOnAwake;

    SpriteRenderer SR;
    int count;
    int spritecount;
    int nowSprite;
    [System.NonSerialized] public bool active;

    void Awake()
    {
        //sprites =  Resources.LoadAll<Sprite>("Image/runner/");
        SR = GetComponent<SpriteRenderer>();
        spritecount = sprites.Length;
        nowSprite = offset;
        active = playOnAwake;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            count++;
            if (count == frame)
            {
                count = 0;
                nowSprite = (nowSprite + 1) % spritecount;
                SR.sprite = sprites[nowSprite];
            }
        }
    }

}
