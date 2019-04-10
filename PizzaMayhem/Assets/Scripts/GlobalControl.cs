using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public int lives;
    public int ammo;

    // this script will hold everything that needs to be saved and load it into each scene

    void Awake()
    {

        // ensures we always have the original gameobject so it can be carried over
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

}
