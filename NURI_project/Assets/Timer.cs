using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public float totalTime = 60.0f;
    public static float currentTime;
    public TMP_Text timerText;  

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime >1)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
    }
    void UpdateTimerDisplay()
    {
        timerText.text = currentTime.ToString("F0");
    }

}