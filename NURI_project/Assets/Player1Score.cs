using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Score: MonoBehaviour
{
    public TMP_Text resultText;
    private int blackCnt;
    private float colorCnt;
    private float arraySizeHalf;
    public static int player1Score;
    public GameObject LosePlayer1;
    public GameObject WinPlayer1;
    public GameObject DrawPlayer1;
    // Start is called before the first frame update
    void Start()
    {
        arraySizeHalf=Divide_Array.arraySizeHalf;
        for(int i=0;i<arraySizeHalf;i++){
            if(Draw_PixcelData_Player1.buffer[i]==Color.black){
                blackCnt+=1;
            }
        }

        colorCnt=arraySizeHalf-blackCnt;
        player1Score=Mathf.RoundToInt(colorCnt/arraySizeHalf*100);

        resultText.text =player1Score.ToString()+"%";
    }

    // Update is called once per frame
    void Update()
    {
        if(player1Score>Player2Score.player2Score){
            WinPlayer1.SetActive(true);
        }
        if(player1Score<Player2Score.player2Score){
            LosePlayer1.SetActive(true);
        }
        if(player1Score==Player2Score.player2Score){
            DrawPlayer1.SetActive(true);
        }
        
    }
}
