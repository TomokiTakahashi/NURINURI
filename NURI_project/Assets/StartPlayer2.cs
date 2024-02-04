using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlayer2 : MonoBehaviour
{
    private Player2Pointer player2Pointer;
    public bool player2Switch;
    private int cnt;
    public static bool childMode;

    void Start(){
         cnt=0;
         player2Switch=false;
    }
    void Update()
    {        
        player2Pointer = GameObject.Find("Player2Pointer").GetComponent<Player2Pointer>();

        if((new Vector3(player2Pointer.player2XOnUnity,0,player2Pointer.player2YOnUnity)- new Vector3(128,0,106)).magnitude<40){
            childMode=false;
            player2Switch=true;
            cnt=0;
        }else if((new Vector3(player2Pointer.player2XOnUnity,0,player2Pointer.player2YOnUnity)- new Vector3(128,0,360)).magnitude<40){
            childMode=true;
            player2Switch=true;
            cnt=0;
        }else{
            player2Switch=false;
            cnt+=1;
            if(cnt>=100){
                player2Switch=false;
                cnt=0;
            }
        }
    }
}