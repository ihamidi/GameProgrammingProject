using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBossHealthbar1 : MonoBehaviour
{
    Vector2 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = SecondBoss1.currentHealth;
        transform.localScale = localScale;
    }
}
