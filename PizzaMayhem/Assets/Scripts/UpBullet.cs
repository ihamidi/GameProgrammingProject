using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(5);
            
        }
        Destroy(gameObject);
    }
}
