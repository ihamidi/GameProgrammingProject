using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    private float rechargeTime;
    public float publicRechargeTime;
    public Rigidbody2D rigid;

    /*private void Update()
    {
        if(rechargeTime <= 0)
        {
            rechargeTime = publicRechargeTime;
        }
        else
        {
            rechargeTime -= Time.deltaTime;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(5);

        }
        if (collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
