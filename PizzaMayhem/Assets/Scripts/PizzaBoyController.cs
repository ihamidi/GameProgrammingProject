using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PizzaBoyController : MonoBehaviour
{
    public static float speed = 7;
    private Rigidbody2D rb;
    private Vector2 moveSpeed;
    bool faceRight;
    bool faceLeft;
    public Text LifeCounter;
    public Text ac;
    public int lives = 3;
    public int ammo;
    public Animator animator;
    public AudioSource OhBoy;
    public AudioSource ImHurt;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletUpPrefab;
    public GameObject cutterPrefab;
    // public Text AmmoCount;
    //public int ammo;
    private float rechargeTime;
    public float publicRechargeTime;
    public AudioSource shoot_sound;

    private float dirX, dirY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Find a reference to the ScoreCounter GameObject
        //GameObject LifeCount = GameObject.Find("Lifecount"); // 2
        //GameObject AmmoCount = GameObject.FindGameObjectWithTag("AmmoCount");
        
         //loads data from GlobalControl script
         lives = GlobalControl.Instance.lives;
         ammo = GlobalControl.Instance.ammo;
       /*
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            LoadPlayer();
            LoadAmmo();
        }
        else
        {
            lives = 3;
            ammo = 0;
        }
        */
        
       
        ac.text = ammo.ToString();
        LifeCounter.text = lives.ToString();

    }

    private void Update()
    {
        dirX = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        dirY = Mathf.RoundToInt(Input.GetAxis("Vertical"));
        Vector2 moveInput = new Vector2(dirX, dirY);
        moveSpeed = moveInput.normalized * speed;
        if(dirX == 0 && dirY == 1)
        {
            animator.SetInteger("Direction", 1);
        }
        if (dirX == 1 && dirY == 0)
        {
            animator.SetInteger("Direction", 3);
        }
        if (dirX == 0 && dirY == -1)
        {
            animator.SetInteger("Direction", 5);
        }
        if (dirX == -1 && dirY == 0)
        {
            animator.SetInteger("Direction", 7);
        }
        if (dirX == 0 && dirY == 0)
        {
            animator.SetInteger("Direction", 0);
        }


        ammo = int.Parse(ac.text);
        if (Input.GetMouseButtonDown(1))
        {
            ammo = int.Parse(ac.text);
            if (ammo > 0)
            {
                ammo--;
                ac.text = ammo.ToString();
                shoot_sound.Play();
                Shoot();
            }
        }

        if (rechargeTime <= 0)
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

        SavePlayer();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime);
        Flip();
    }

    private void Flip()
    {
        if ((faceRight && Input.GetKey(KeyCode.LeftArrow)))
        {
            faceLeft = true;
            faceRight = false;
            transform.Rotate(0f, 180f, 0f);
        }
        if ((faceLeft && Input.GetKey(KeyCode.RightArrow)))
        {
            faceRight = true;
            faceLeft = false;
            transform.Rotate(0f, 180f, 0f);
        }
    } 
    void OnTriggerEnter2D(Collider2D coll)
    {
        ImHurt.Play();
        lives = int.Parse(LifeCounter.text);
        if(coll.gameObject.tag=="CheeseBall")
            lives -= 1;
        if (coll.gameObject.tag == "Enemy")
            lives -= 1;
        if (lives==0)
        {
            SceneManager.LoadScene(5);
        }
        // Convert the score back to a string and display it
        LifeCounter.text = lives.ToString();
    }


    public void LoadByIndex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }

    
    public void SavePlayer()
    {
        //SaveSystem.SaveLives(this);
        GlobalControl.Instance.ammo = ammo;
        GlobalControl.Instance.lives = lives;
        
    }

    /*
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        lives = data.lives;
        ammo = data.ammo;
    }

    public void SaveAmmo()
    {
       SaveSystem.SaveAmmo(this);
    }

    public void LoadAmmo()
    {
        PlayerData data = SaveSystem.LoadAmmo();

        ammo = data.ammo;
    }
    */


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
