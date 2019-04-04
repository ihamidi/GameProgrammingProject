using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthItem : MonoBehaviour
{
    private Transform player;
    public GameObject LifeCounter;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        LifeCounter = GameObject.FindGameObjectWithTag("Lifecount");
    }

    public void Use()
    {
        Destroy(gameObject);
        Text lc = LifeCounter.GetComponent<Text>();
        int lives = int.Parse(lc.text);

        if(lives < 5)
            lives += 1;


        // Convert the score back to a string and display it
        lc.text = lives.ToString();
        
            
    }
   
}
