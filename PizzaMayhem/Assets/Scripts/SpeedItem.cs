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
    Image myImageComponent;
    public Sprite speedImage; 
    public Sprite usedImage;



    void Start()
    {
        myImageComponent = GetComponent<Image>();
        myImageComponent.sprite = speedImage;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        speed = PizzaBoyController.speed;
    }


    public void Use()
    {
        if (!myImageComponent.sprite.Equals(usedImage))
        StartCoroutine(speedBoostTime());
    }

    IEnumerator speedBoostTime()
    {
        myImageComponent.sprite = usedImage;
        Debug.Log("PizzaBoy Speed:" + PizzaBoyController.speed);
        PizzaBoyController.speed = speed * 2.5f;
        speed = PizzaBoyController.speed;
        yield return new WaitForSeconds(3f);
        PizzaBoyController.speed = 7;

        Destroy(gameObject);

    }
}
