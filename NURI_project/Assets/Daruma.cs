using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daruma : MonoBehaviour
{
    public GameObject RearDarumaPlayer1;
    public GameObject RearDarumaPlayer2;
    public GameObject FrontDarumaPlayer1;
    public GameObject FrontDarumaPlayer2;

    private static bool movePlayer1Switch;
    private static bool movePlayer2Switch;

    private int stopTimePlayer1;
    private int stopTimePlayer2;
    
    // Start is called before the first frame update
    void Start()
    {
        stopTimePlayer1=150;
        stopTimePlayer2=150;

        movePlayer1Switch=false;
        movePlayer2Switch=false;
    }

    // Update is called once per frame
    void Update()
    {
        //もとは後ろ向きのだるまを描画しておく。
        if(movePlayer1Switch==false){
            RearDarumaPlayer1.SetActive(true);
            FrontDarumaPlayer1.SetActive(false);
        }
        if(movePlayer2Switch==false){
            RearDarumaPlayer2.SetActive(true);
            FrontDarumaPlayer2.SetActive(false);
        }

        //スイッチがオフの時の処理
        if(movePlayer1Switch==false){
            if(stopTimePlayer1>0){
                stopTimePlayer1-=1;

                if(Get_Player_Coordinate.transDistancePlayer1>150){
                    movePlayer1Switch=true;
                }
            }else{
                stopTimePlayer1=150;
                Item.darumaSwitch=false;
                Item.itemExist=false;
                }
           

        }  
        
        //スイッチがONの時の処理。
        if(movePlayer1Switch==true){
            Draw_PixcelData_Player1.canDraw=false;
        }
    }
}
