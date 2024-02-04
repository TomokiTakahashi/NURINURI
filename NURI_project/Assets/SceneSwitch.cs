using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    private StartPlayer1 startPlayer1;
    private StartPlayer2 startPlayer2;

    private int cnt;

    void Start(){
        cnt=0;
    }


    void Update()
    {
        startPlayer1 = GameObject.Find("Player1Cort").GetComponent<StartPlayer1>();
        startPlayer2 = GameObject.Find("Player2Cort").GetComponent<StartPlayer2>();

        if(startPlayer1.player1Switch==true && startPlayer2.player2Switch==true){
            cnt+=1;
        }else{
            cnt=0;
        }

        if(cnt>=50){
            SceneManager.LoadScene("LoadScene");
        }

        

    }
}
