﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionButton : MonoBehaviour
{
    public void LoadByIndex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }
}
