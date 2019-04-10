using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PizzaBoyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 moveSpeed;
    bool faceRight;
    bool faceLeft;
    public Text LifeCounter;
    public Text ac;
    public int lives;
    public int ammo;
    public Animator animator;
    public AudioSource OhBoy;
    public AudioSource ImHurt;

    private float dirX, dirY;

    private void Start()
    {
        OhBoy.Play();
        rb = GetComponent<Rigidbody2D>();
        // Find a reference to the ScoreCounter GameObject
        GameObject LifeCount = GameObject.Find("Lifecount"); // 2
        GameObject AmmoCount = GameObject.FindGameObjectWithTag("AmmoCount");
        // lives save
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            LoadPlayer();
        }
        else
        {
            lives = 3;
            ammo = 0;
        }
       
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
        SaveSystem.SaveLives(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        lives = data.lives;
        ammo = data.ammo;
    }

   /* public void SaveAmmo()
    {
       SaveSystem.SaveAmmo(this);
    }

    public void LoadAmmo()
    {
        PlayerData data = SaveSystem.LoadAmmo();

        ammo = data.ammo;
    }*/

}
