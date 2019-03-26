using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene is '" + scene.name + ".");
        if (scene.name== "MainMenu")
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
            
    }
}