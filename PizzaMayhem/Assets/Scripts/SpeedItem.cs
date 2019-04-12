using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class SpeedItem : MonoBehaviour
{
    private Transform player;
    public static float speed;
    public float time = 5.0f;
    public float countDown;
    public bool usingSpeed = false;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        countDown = time;
        speed = PizzaBoyController.speed;

    }

    void Update()
    {
        if(usingSpeed == true)
        {
            speed = 14;
            PizzaBoyController.speed = speed;
            countDown -= 1 * Time.deltaTime;

            if(countDown <= 0)
            {
                usingSpeed = false;
                countDown = time;
                speed = 7;
                PizzaBoyController.speed = speed;
            }
        }
    }

    public void Use()
    {
        Destroy(gameObject);
        usingSpeed = true;
        Update();
    }
}
