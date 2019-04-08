using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class AmmoItem : MonoBehaviour
{
    private Transform player;
    public GameObject AmmoCount;
    public Text ac;
    public int ammo;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        AmmoCount = GameObject.FindGameObjectWithTag("AmmoCount");
        ac = AmmoCount.GetComponent<Text>();
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            LoadAmmo();
        }
        else
        {
            ammo = 0;
        }
        ac.text = ammo.ToString();
    }

    public void Use()
    {
        Destroy(gameObject);
        ammo = int.Parse(ac.text);

        if (ammo < 20)
            ammo += 10;

        // Convert the score back to a string and display it
        ac.text = ammo.ToString();


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
}
