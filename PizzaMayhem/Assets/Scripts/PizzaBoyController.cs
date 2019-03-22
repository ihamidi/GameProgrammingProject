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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        faceRight = true;
        // Find a reference to the ScoreCounter GameObject
        GameObject LifeCount = GameObject.Find("Lifecount"); // 2
        LifeCounter.text = "3";
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveSpeed = moveInput.normalized * speed;
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
        int lives = int.Parse(LifeCounter.text);
        if(coll.gameObject.tag=="Bullet" || coll.gameObject.tag=="CheeseBall")
            lives -= 1;
        if(lives==0)
        {
            LoadByIndex(0);
        }
        // Convert the score back to a string and display it
        LifeCounter.text = lives.ToString();
      



    }
    public void LoadByIndex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }
}
