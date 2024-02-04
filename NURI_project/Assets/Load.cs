using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Load : MonoBehaviour
{
    public float totalTime = 5.0f;
    private float currentTime;
    public TMP_Text loadText;  

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime >0)
        {
            currentTime -= (Time.deltaTime);
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        loadText.text = currentTime.ToString("F0");//テキストに秒数を表示させる
    }

}