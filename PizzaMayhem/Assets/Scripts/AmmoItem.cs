using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class AmmoItem : MonoBehaviour
{
    private Transform player;
    public GameObject AmmoCount;
    public int ammo;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        AmmoCount = GameObject.FindGameObjectWithTag("AmmoCount");
    }

    public void Use()
    {
        Destroy(gameObject);
        Text ac = AmmoCount.GetComponent<Text>();
        ammo = int.Parse(ac.text);

        if (ammo < 20)
            ammo += 10;

        // Convert the score back to a string and display it
        ac.text = ammo.ToString();


    }
}
