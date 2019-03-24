using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    private Transform player;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    { //not working but basic idea for spawn
        if (player.position.x ==  51.18 && player.position.y == 57.43)
        {
            Instantiate(boss, new Vector2(41, 58), Quaternion.identity);
        }
    }
}
