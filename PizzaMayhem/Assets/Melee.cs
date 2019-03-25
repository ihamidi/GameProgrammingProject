using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigid;

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
