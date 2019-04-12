using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoBlock : MonoBehaviour
{
    public GameObject door;

    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Boss") == null)
        {
            door.SetActive(true);
        }
    }
}
