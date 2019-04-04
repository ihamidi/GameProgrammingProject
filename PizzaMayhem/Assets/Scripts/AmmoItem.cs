using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    private Transform playerPos;
    private int ammo;

    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        ammo = Shooting.ammo;
    }

    public void Use()
    {
        Destroy(gameObject);
        ammo += 10;


    }
}
