using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealthBar : MonoBehaviour
{
    Vector2 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = FinalBoss.currentHealth;
        transform.localScale = localScale;
    }
}
