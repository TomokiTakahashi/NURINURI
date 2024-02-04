/*もともと用意している画像のpixcelデータを置き換えすることができるスクリプトです。アイテムなどを作成する場合にはこちらのスクリプトを参照することになるとは思います。
塗りに使う仕組みを変更する場合には少しプログラムを変える必要があると思います。
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_PixcelData_Player1 : MonoBehaviour
 {
    Texture2D drawTexture;
    public static Color[] buffer;
    private int drawWidth;
    public static bool canDraw;

    void Start () {
        //脳死で使っていいやつ。とりあえずstartに書きましょう//////////////////////////////////////////////////
        Texture2D mainTexture = (Texture2D) GetComponent<Renderer> ().material.mainTexture;             ////
        Color[] pixels = mainTexture.GetPixels();                                                       ////
        buffer = new Color[pixels.Length];                                                              ////
        pixels.CopyTo (buffer, 0);                                                                      ////
        drawTexture = new Texture2D (mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);///
        drawTexture.filterMode = FilterMode.Point;                                                      ////
        ///ここまでは脳死ゾーン。変更しないでください。////////////////////////////////////////////////////////
        canDraw=true;
    }

    //色塗る用の関数
    void DrawPlayerCort(int playerX ,int playerY,bool mode)
    {
        string colorString = "#41F45A"; 
        Color newColor;
        ColorUtility.TryParseHtmlString(colorString, out newColor); // 新しくColorを作成
         if(mode==true){
            drawWidth=15;
         }else{
            drawWidth=10;
         }
          for(int x = 0; x < drawTexture.width; x++){
            for(int y = 0; y <drawTexture.height; y++){
                if((new Vector2(playerX,playerY)-new Vector2(x,y)).magnitude<drawWidth){
                    buffer.SetValue (newColor, x + 256 * y);
                }
            }
        }
    }

    //色塗る用の関数
    public void bom(int itemXOnArray,int itemYOnArray){
        for(int x = 0; x < drawTexture.width; x++){
            for(int y = 0; y <drawTexture.height; y++){
                if((new Vector2(itemXOnArray,itemYOnArray)-new Vector2(x,y)).magnitude<70){
                    buffer.SetValue (Color.black, x + 256 * y);
                }
            }
        }
    }

    void Update () 
    {
        if(canDraw==true){
            DrawPlayerCort(Get_Player_Coordinate.player1X,Get_Player_Coordinate.player1Y,StartPlayer1.childMode);
        }

        if(Item.bomSwitch==true && Bom.bomCnt==1 && Bom.whoHaveBom==1){
            bom(Bom.bomXOnArray,Bom.bomYOnArray);
            Bom.bomCnt=500;
            Item.bomSwitch=false;
            Item.itemExist=false;
        }


        //書き換えたピクセルを描画してくれています。そっとしておきましょう//
        drawTexture.SetPixels (buffer);                             ////
        drawTexture.Apply ();                                       ////
        GetComponent<Renderer> ().material.mainTexture = drawTexture;///
        ///ここまではそっとしておいてほしいゾーン//////////////////////////
    }
}


