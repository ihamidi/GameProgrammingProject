using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public Text AmmoCount;
    public int ammo;

    private void Start()
    {
        

        AmmoCount.text = ammo.ToString();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        ammo = int.Parse(AmmoCount.text);
        if (coll.gameObject.tag == "Player")
        {
            ammo += 20;
            Destroy(gameObject);
        }
            
        // Convert the score back to a string and display it
        AmmoCount.text = ammo.ToString();
    }

}
