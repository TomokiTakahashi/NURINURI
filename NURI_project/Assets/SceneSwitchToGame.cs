using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchToGame : MonoBehaviour
{
    private float totalTime = 5.0f;
    private float currentTime;
    

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime >0)
        {
            currentTime -= (Time.deltaTime);
        }else{
            SceneManager.LoadScene("GameScene");
        }
    }
}
