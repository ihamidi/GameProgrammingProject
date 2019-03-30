using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthItem : MonoBehaviour
{
    private Transform player;
    public Text LifeCounter;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        Destroy(gameObject);
        int lives = int.Parse(LifeCounter.text);
        
            lives += 1;


        // Convert the score back to a string and display it
        LifeCounter.text = lives.ToString();
        
            
    }
   
}
