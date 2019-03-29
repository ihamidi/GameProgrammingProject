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
        // call function to add lives to counter
        AddLife();
    }

    public void AddLife()
    {
        int lives = int.Parse(LifeCounter.text);
        lives += 1;

        LifeCounter.text = lives.ToString();
        Destroy(gameObject);
    }
}
