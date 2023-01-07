using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public GameObject middle;//ステージの真ん中
    public GameObject egde;//ステージの右端
    public GameObject player;
    private Vector2 playerPos;
    private Vector2 middlePos;
    private Vector2 edgePos;

    private int createstopper = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        middlePos.x = middle.transform.position.x;
        edgePos.x = egde.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos.x = player.transform.position.x;

        if (playerPos.x > edgePos.x)
        {
            createstopper = 0;
            Destroy(this.gameObject, 1.5f);
        }
    }
}
