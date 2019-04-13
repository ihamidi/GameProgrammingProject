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

        StartCoroutine(speedBoostTime());
    }

    IEnumerator speedBoostTime()
    {
        myImageComponent.sprite = usedImage;
        PizzaBoyController.speed = speed * 3;
        speed = PizzaBoyController.speed;
        yield return new WaitForSeconds(1f);
        PizzaBoyController.speed = speed / 3;

        Destroy(gameObject);

    }
}
