using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int scene;
    public void LoadByIndex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }

}
