using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossHealthbar2 : MonoBehaviour
{
    Vector2 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = SecondBoss2.currentHealth;
        transform.localScale = localScale;
    }
}
