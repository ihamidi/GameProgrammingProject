using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public Text AmmoCount;


    void OnTriggerEnter2D(Collider2D coll)
    {

        int ammo = int.Parse(AmmoCount.text);
        if (coll.gameObject.tag == "Player")
            ammo += 20;


        // Convert the score back to a string and display it
        AmmoCount.text = ammo.ToString();
        if (coll.gameObject.tag == "Player")
            Destroy(gameObject);

    }

}
