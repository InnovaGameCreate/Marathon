using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAcceleration : MonoBehaviour
{
    public GameObject player;
    private Vector2 playerPos;
    private Vector2 thisPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        thisPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;


        if (playerPos.x >= thisPos.x && thisPos.y <= playerPos.y)
        {
            Distance.SPS += 0.5f;
            Destroy(this.gameObject);
        }
    }
}
