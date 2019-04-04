using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Vector2 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = Enemy.currentHealth;
        transform.localScale = localScale;
    }
}
