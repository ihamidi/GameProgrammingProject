using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Text LifeCounter;
    

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        int lives = int.Parse(LifeCounter.text);
        if (coll.gameObject.tag == "Player") 
            lives += 1;


        // Convert the score back to a string and display it
        LifeCounter.text = lives.ToString();
        if (coll.gameObject.tag == "Player")
            Destroy(gameObject);

    }

}
