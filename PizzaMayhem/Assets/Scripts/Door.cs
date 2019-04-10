using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
 
    public void LoadByIndex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            LoadByIndex(2);
            //PizzaBoyController boy = coll.GetComponent<PizzaBoyController>();
            //boy.SavePlayer();
            //AmmoItem ammo = coll.GetComponent<AmmoItem>();
            //ammo.SaveAmmo();
        }    
            
        
    }
}
