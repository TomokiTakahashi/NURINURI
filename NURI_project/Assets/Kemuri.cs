using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kemuri : MonoBehaviour
{
    public GameObject KemuriItem;
    public GameObject KemuriEffect;
   
    private bool effectSwitch;//アイテムにさわったわ切り替える。

    private static int kemuriX;
    private static int kemuriY;

    private int kemuriXOnArray;
    private static int kemuriYOnArray;

    private int distance;//playerとの距離

    public static int whoHaveKemuri;//整数型。１か２どちらかの値を格納する。

    public static int kemuriWidth;//生成時に必要な幅の情報

    private int effectX;
    private int effectY;

    private int effectWidth;
    private int effectHeight;

    private int effectCnt;

    private int textureWidth;
    private int textureHeight;

    void Start()
    {
        textureWidth=256;
        textureHeight=424;
         distance=40;
         effectCnt=200;
         kemuriWidth=10;

         effectWidth=100;
         effectHeight=20;

         effectSwitch=false;

        //初期の配置を決める
         whoHaveKemuri=Random.Range(1,3);
        
         if(whoHaveKemuri==1){
                kemuriX=Random.Range(-kemuriWidth,-textureWidth+kemuriWidth);
                kemuriY=Random.Range(kemuriWidth,textureHeight-kemuriWidth);
                kemuriXOnArray= -kemuriX;
                kemuriYOnArray=textureHeight-kemuriY;
            }else{
                kemuriX=Random.Range(kemuriWidth,textureWidth-kemuriWidth);
                kemuriY=Random.Range(kemuriWidth,textureHeight-kemuriWidth);
                kemuriXOnArray=textureWidth-kemuriX;
                kemuriYOnArray=textureHeight-kemuriY;
            }
    }
    //当たり判定を付ける関数
     void TouchPlayer(int playerX, int plaxerY,int itemXOnArray, int itemYOnArray){
         if((new Vector2(playerX,plaxerY)- new Vector2(itemXOnArray,itemYOnArray)).magnitude <= distance){
             if(whoHaveKemuri==1){
                 effectX=Random.Range(effectWidth,textureWidth-effectWidth);
                 effectY=Random.Range(effectHeight,textureHeight-effectHeight);
                 effectSwitch=true;
             }else if(whoHaveKemuri==2){
                 effectX=Random.Range(-effectWidth,-textureWidth+effectWidth);
                 effectY=Random.Range(effectHeight,textureHeight-effectHeight);
                 effectSwitch=true;
            }
         }
     }
    void Update(){
        
        if(effectSwitch==false){
            KemuriItem.SetActive(true);
            KemuriEffect.SetActive(false);
            KemuriItem.transform.position = new Vector3(kemuriX,1, kemuriY);
                if(whoHaveKemuri==1){
                TouchPlayer(Get_Player_Coordinate.player1X,Get_Player_Coordinate.player1Y,kemuriXOnArray,kemuriYOnArray);
            }
                 if(whoHaveKemuri==2){
                TouchPlayer(Get_Player_Coordinate.player2X,Get_Player_Coordinate.player2Y,kemuriXOnArray,kemuriYOnArray);
            }
         }else if(effectSwitch==true){

             KemuriItem.SetActive(false);
             KemuriEffect.SetActive(true);
            if(effectCnt>0){
                effectCnt-=1;
                KemuriEffect.transform.position = new Vector3(effectX,1, effectY);
            }else{
                effectCnt=200;
                Item.itemExist=false;
                whoHaveKemuri=Random.Range(1,3);
        
                if(whoHaveKemuri==1){
                kemuriX=Random.Range(-kemuriWidth,-textureWidth+kemuriWidth);
                kemuriY=Random.Range(kemuriWidth,textureHeight-kemuriWidth);
                kemuriXOnArray= -kemuriX;
                kemuriYOnArray=textureHeight-kemuriY;
               }else{
                
                kemuriX=Random.Range(kemuriWidth,textureWidth-kemuriWidth);
                kemuriY=Random.Range(kemuriWidth,textureHeight-kemuriWidth);
                kemuriXOnArray=textureWidth-kemuriX;
                kemuriYOnArray=textureHeight-kemuriY;
              }

            KemuriEffect.SetActive(false);
            effectSwitch=false;
            Item.kemuriSwitch=false;
            }
         }
}
}