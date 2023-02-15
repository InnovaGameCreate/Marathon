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
    }

    // Update is called once per frame
    void Update()
    {
        playerPos.x = player.transform.position.x;

        thisPos.x = this.transform.position.x;

        if (playerPos.x > thisPos.x)
        {
            Distance.SPS += 0.5f;
            Destroy(this.gameObject);
        }
    }
}
