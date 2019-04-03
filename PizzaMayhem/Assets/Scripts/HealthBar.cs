using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image foregroundImage;
    public float updateSpeedSeconds = 0.5f;


    private void Start()
    {
        //GetComponentInParent<FirstBoss>().OnHealthPctChanged += HandleHealthChanged;
        //GetComponentInParent<Enemy>().OnHealthPctChanged += HandleHealthChanged;
    }

    private void HandleHealthChanged(float pct)
    {
        foregroundImage.fillAmount = pct;
    }
}
