using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchToResult : MonoBehaviour
{
    private int arraySizeHalf;

    void Start(){
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Timer.currentTime<1){
            SceneManager.LoadScene("ResultScene");
        }    
        
    }
}
