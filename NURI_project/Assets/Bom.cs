using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bom : MonoBehaviour
{
    public static int bomX;
    public static int bomY;

    public static int bomXOnArray;
    public static int bomYOnArray;

    private int distance;//playerとの距離

    public static int whoHaveBom;//整数型。１か２どちらかの値を格納する。

    private int bomWidth;//生成時に必要な爆弾の幅の定義

    public static int bomCnt;//爆弾が爆発するまでの時間

    void Start()
    {
         distance=40;
         bomWidth=10;
         bomCnt=500;

        //初期の配置を決める
         whoHaveBom=Random.Range(1,3);
        
         if(whoHaveBom==1){
                bomX=Random.Range(-bomWidth,-Get_Player_Coordinate.textureWidth+bomWidth);
                bomY=Random.Range(bomWidth,Get_Player_Coordinate.textureHeight-bomWidth);
                bomXOnArray=-bomX;
                bomYOnArray=Get_Player_Coordinate.textureHeight-bomY;
            }else{
                bomX=Random.Range(bomWidth,Get_Player_Coordinate.textureWidth-bomWidth);
                bomY=Random.Range(bomWidth,Get_Player_Coordinate.textureHeight-bomWidth);
               
                bomXOnArray=Get_Player_Coordinate.textureWidth-bomX;
                bomYOnArray=Get_Player_Coordinate.textureHeight-bomY;
            }
        transform.position = new Vector3(bomX,1, bomY);
    }

    //当たり判定を付ける関数
     void TouchPlayer(int playerX, int plaxerY,int itemXOnArray, int itemYOnArray){
         if((new Vector2(playerX,plaxerY)- new Vector2(itemXOnArray,itemYOnArray)).magnitude <= distance){
             if(whoHaveBom==1){
                 bomX=Random.Range(bomWidth,Get_Player_Coordinate.textureWidth-bomWidth);
                 bomY=Random.Range(bomWidth,Get_Player_Coordinate.textureHeight-bomWidth);

                 bomXOnArray=Get_Player_Coordinate.textureWidth-bomX;
                 bomYOnArray=Get_Player_Coordinate.textureHeight-bomY;
                 whoHaveBom=2;
             }else if(whoHaveBom==2){
                 bomX=Random.Range(-bomWidth,-Get_Player_Coordinate.textureWidth+bomWidth);
                 bomY=Random.Range(bomWidth,Get_Player_Coordinate.textureHeight-bomWidth);
                
                 bomXOnArray=-bomX;
                 bomYOnArray=Get_Player_Coordinate.textureHeight-bomY;
                 whoHaveBom=1;
            }
            transform.position = new Vector3(bomX,1, bomY);
         }
     }


    void Update(){
        if(bomCnt>1){
            bomCnt-=1;
        }

        if(whoHaveBom==1){
            TouchPlayer(Get_Player_Coordinate.player1X,Get_Player_Coordinate.player1Y,bomXOnArray,bomYOnArray);
        }
        if(whoHaveBom==2){
            TouchPlayer(Get_Player_Coordinate.player2X,Get_Player_Coordinate.player2Y,bomXOnArray,bomYOnArray);
        }
    }
}