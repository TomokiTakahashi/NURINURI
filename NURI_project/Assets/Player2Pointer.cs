using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Pointer : MonoBehaviour
{
    public int player2XOnUnity;
    public int player2YOnUnity;
    private int cortWidth;
    private int cortHeight;
    // Start is called before the first frame update
    void Start()
    {
        cortWidth=256;
        cortHeight=424;
    }

    // Update is called once per frame
    void Update()
    {
        //配列上の値からUnity座標に変換する
        player2XOnUnity=cortWidth-Get_Player_Coordinate.player2X;
        player2YOnUnity=cortHeight-Get_Player_Coordinate.player2Y;

       transform.position = new Vector3(player2XOnUnity,0, player2YOnUnity);
        
    }
}