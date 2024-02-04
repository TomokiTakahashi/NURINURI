//このスクリプトでは各コートから一番浅い点の座意表を求めます。前段階でコートは分割されているので幅の数値が少し異なります。
//スタート画面などで各プレイヤーの座標が必要となる場合はここの変数を外部参照することになるでしょう。
//一番浅くなる座標がおそらく複数出てくることになるのでx,y座標ともに平均値を出すアルゴリズムにしています。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Get_Player_Coordinate : MonoBehaviour
{
    Divide_Array Divide_Array;

    public static int textureWidth;
    public static int textureHeight;

    public static int transDistancePlayer1;
    public static int transDistancePlayer2;
    
    public static int player1X;
    public static int player1Y;

    public static int player2X;
    public static int player2Y;

    private int previousPlayer1X;
    private int previousPlayer1Y;

    private int previousPlayer2X;
    private int previousPlayer2Y;

    private float LPF=0.8f;

    // Start is called before the first frame update
    void Start()
    {
        textureWidth=256;
        textureHeight=424;
    }

    void Update()
    {
        //中点を求めるために定義しています
        int player1_Min_Sum_x=0;
        int player1_Min_Sum_y=0;
        int player2_Min_Sum_x=0;
        int player2_Min_Sum_y=0;
        int player1_counter=0;
        int player2_counter=0;

       
        int player1_Min=Divide_Array.player1Cort.Min();
        int player2_Min=Divide_Array.player2Cort.Min();


         for(int x=0; x<textureWidth;x++){
            for(int y=0;y<textureHeight;y++){
                if(Divide_Array.player1Cort[x+y*textureWidth]==player1_Min){
                    player1_Min_Sum_x+=x;
                    player1_Min_Sum_y+=y;
                    player1_counter+=1;
                   
                }
                if(Divide_Array.player2Cort[x+y*textureWidth]==player2_Min){
                    player2_Min_Sum_x+=x;
                    player2_Min_Sum_y+=y;
                    player2_counter+=1;
                }
            }
         }

        //現在の座標を求める
         player1X=player1_Min_Sum_x/player1_counter;
         player2X=player2_Min_Sum_x/player2_counter;

         player1Y=player1_Min_Sum_y/player1_counter;
         player2Y=player2_Min_Sum_y/player2_counter;  

        //ノイズを除去する
        player1X=Mathf.RoundToInt(player1X*LPF+previousPlayer1X*(1-LPF));
        player1Y=Mathf.RoundToInt(player1Y*LPF+previousPlayer1Y*(1-LPF));
        player2X=Mathf.RoundToInt(player2X*LPF+previousPlayer2X*(1-LPF));
        player2Y=Mathf.RoundToInt(player2Y*LPF+previousPlayer2Y*(1-LPF));

        //移動距離を求める
        transDistancePlayer1=Mathf.RoundToInt((new Vector2(player1X,player1Y)-new Vector2(previousPlayer1X,previousPlayer1Y)).magnitude);
        transDistancePlayer2=Mathf.RoundToInt((new Vector2(player2X,player2Y)-new Vector2(previousPlayer2X,previousPlayer2Y)).magnitude);

        //ひとつ前の値を保持する
        previousPlayer1X=player1X;
        previousPlayer1Y=player1Y;
        previousPlayer2X=player2X;
        previousPlayer2Y=player2Y;
    }
}
