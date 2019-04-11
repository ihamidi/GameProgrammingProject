using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class SpeedItem : MonoBehaviour
{
    private Transform player;
    private float speed;
    private float time = 15.0f;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    public void Use()
    {
        Destroy(gameObject);
        speed = PizzaBoyController.speed;
        while (time > 0)
        {
            speed = 14;
            PizzaBoyController.speed = speed;
            time -= Time.deltaTime;
        }
    }
}
