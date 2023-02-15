using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public GameObject player;
    [Tooltip("床の移動距離を自由に設定する")]
    public float length;
    [Tooltip("プレイヤーをどの高さから感知するのかを自由に設定する")]
    public float Ysensor;
    private Vector2 playerPos;
    private Vector2 thisPos;
    private Vector2 Pre_thisPos;

    private BoxCollider2D box2D;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Pre_thisPos = this.transform.position;
        box2D = GetComponent<BoxCollider2D>();

        box2D.offset = new Vector2(0, 0.4f);
        box2D.size = new Vector2(1, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;
        thisPos = this.transform.position;

        if ((thisPos.x - 4.5f <= playerPos.x && playerPos.x <= thisPos.x + 4.5f) && (thisPos.y <= playerPos.y && playerPos.y <= thisPos.y + Ysensor))
        {
            if (Pre_thisPos.x + length > thisPos.x)
            {
                this.gameObject.transform.Translate(Distance.speed * Distance.slope * Distance.dash * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }
}
