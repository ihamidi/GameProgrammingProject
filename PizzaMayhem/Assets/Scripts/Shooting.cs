using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletUpPrefab;
    public GameObject cutterPrefab;
    private float rechargeTime;
    public float publicRechargeTime;

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(rechargeTime <= 0)
        {
            if (Input.GetKey("space"))
            {
                MeleeEnemy();
            }
            rechargeTime = publicRechargeTime;
        }
        else
        {
            rechargeTime -= Time.deltaTime;
        }
            
    }

    private void Shoot()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (worldMousePos - transform.position);
        direction.Normalize();

        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate(
                                bulletPrefab,
                                transform.position,
                                Quaternion.identity);
        Debug.Log(direction.x + " " + direction.y);
                // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10;
    }

    private void MeleeEnemy()
    {
        Instantiate(cutterPrefab, firePoint.position, firePoint.rotation);
    }
}
