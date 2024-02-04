using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlayer1 : MonoBehaviour
{
    private Draw_PixcelData_Player1 drawPlayer1;
    private Player1Pointer player1Pointer;
    public bool player1Switch;
    private int cnt;
    public  static bool childMode;

    void Start(){
         cnt=0;
         player1Switch=false;

    }
    void Update()
    {        
        player1Pointer = GameObject.Find("Player1Pointer").GetComponent<Player1Pointer>();


        if((new Vector3(player1Pointer.player1XOnUnity,0,player1Pointer.player1YOnUnity)- new Vector3(-128,0,106)).magnitude<50){
            childMode=true;
            player1Switch=true;
            cnt=0;
        }else if((new Vector3(player1Pointer.player1XOnUnity,0,player1Pointer.player1YOnUnity)- new Vector3(-128,0,340)).magnitude<50){
            childMode=false;
            player1Switch=true;
            cnt=0;
        }else{
            cnt+=1;
            if(cnt>=100){
                player1Switch=false;
                cnt=0;
            }
        }
    }
    
}