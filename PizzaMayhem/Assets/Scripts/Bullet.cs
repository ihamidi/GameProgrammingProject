using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigid;

    // Start is called before the first frame update
    //void Start()
    //{
      //  rigid.velocity = transform.right * speed;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damage(5);
            
        }
        if(collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }
}
