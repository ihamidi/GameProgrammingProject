using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    public static float currentHealth = 1f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bullet") {
            Damage(10);
        }
    }

    public void Damage(int damageVal)
    {
        // convert damageVal into percentage
        float damagePct = (float)damageVal / 100;
        currentHealth -= damagePct;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(6);
        }
    }

}
