using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject player;
    public Transform playerSpawnPoint;
    public GameObject LifeCounter;
    public GameObject boss;
    public Transform bossSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        LifeCounter = GameObject.FindGameObjectWithTag("Lifecount");
        Instantiate(player, playerSpawnPoint.position, playerSpawnPoint.rotation);
        Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
    }
}
