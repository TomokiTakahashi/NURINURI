//各コートから深度が最も浅い座標を取り出すために配列を左右に分割するスクリプトです。特にいじるところはないと思います。処理の速度次第ではlinqを使ったコードに書き換えるつもりです。

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Divide_Array : MonoBehaviour
{
    DepthManager DepthManager;

    public static ushort[] player1Cort;//入れ物
    public static ushort[] player2Cort;//入れ物
    
    private ushort[] a;
    public static int textureWidth;
    public static int textureHeight;
    public static int arraySize;
    public static int arraySizeHalf;

    void Start()
    {
        textureWidth=512;
        textureHeight=424;

        arraySize=217088;
        arraySizeHalf=108544;

        a =new ushort[arraySize];
        player2Cort =new ushort[arraySizeHalf];
        player1Cort =new ushort[arraySizeHalf];
    }
    // Update is called once per frame
    
    void Update()
    { 
        DepthManager=GetComponent<DepthManager>();//先輩に聞きたい部分
        a=DepthManager._depthData;
        
        //割と自信がない部分。変更が必要になるとすればここ。plinqを使うにも多分ココ変更の余地あり。pushを付き合うとよいとの趣旨のアドバイスをいただいたよう検討。
        for(int x = 0; x < textureWidth; x++){
			for(int y = 0; y <textureHeight; y++){
                if(x<textureWidth/2){
                     player2Cort[x+textureWidth/2*y]=a[x+textureWidth*y];
                }else{
                     player1Cort[x+textureWidth/2*y-textureWidth/2]=a[x+textureWidth*y];
                }
            }
        }
    }
}

//lengthinpixelを使う