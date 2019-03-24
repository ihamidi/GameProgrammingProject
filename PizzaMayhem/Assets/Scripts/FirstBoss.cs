using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{
    public int health = 100;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet") {
            health = health - 10;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    public void Damage(int damageVal)
    {
        health = health - damageVal;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
