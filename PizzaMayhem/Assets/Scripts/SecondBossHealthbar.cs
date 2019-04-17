using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossHealthbar : MonoBehaviour
{
    Vector2 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = SecondBoss.currentHealth;
        transform.localScale = localScale;
    }
}
