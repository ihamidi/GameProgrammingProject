using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class SpeedItem : MonoBehaviour
{
    private Transform player;
    public static float speed;
    public float time = 1.0f;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = PizzaBoyController.speed;
    }


    public void Use()
    {
        Destroy(gameObject);
        StartCoroutine(speedBoostTime());
    }

    IEnumerator speedBoostTime()
    {
        PizzaBoyController.speed = speed * 3;
        speed = PizzaBoyController.speed;
        yield return new WaitForSeconds(1f);
        PizzaBoyController.speed = speed / 3;
        
    }
}
