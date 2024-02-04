using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player2Score: MonoBehaviour
{
    public TMP_Text resultText;
    private int blackCnt;
    private float colorCnt;
    private float arraySizeHalf;
    public static int player2Score;
    public GameObject LosePlayer2;
    public GameObject WinPlayer2;
    public GameObject DrawPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        arraySizeHalf=Divide_Array.arraySizeHalf;
        for(int i=0;i<arraySizeHalf;i++){
            if(Draw_PixcelData_Player2.buffer[i]==Color.black){
                blackCnt+=1;
            }
        }

        colorCnt=arraySizeHalf-blackCnt;
        player2Score=Mathf.RoundToInt(colorCnt/arraySizeHalf*100);

        resultText.text =player2Score.ToString()+"%";
    }

    void Update()
    {
        if(player2Score>Player1Score.player1Score){
            WinPlayer2.SetActive(true);
        }
        if(player2Score<Player1Score.player1Score){
            LosePlayer2.SetActive(true);
        }
        if(player2Score==Player1Score.player1Score){
            DrawPlayer2.SetActive(true);
        }
        
    }

}