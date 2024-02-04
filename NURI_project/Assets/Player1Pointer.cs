using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Pointer : MonoBehaviour
{
    public int player1XOnUnity;
    public int player1YOnUnity;
    private int cortWidth;
    private int cortHeight;
    // Start is called before the first frame update
    void Start()
    { 
        
        cortHeight=424;
    }

    // Update is called once per frame
    void Update()
    {
        //配列上の値からUnity座標に変換する
        player1XOnUnity=-Get_Player_Coordinate.player1X;
        player1YOnUnity=cortHeight-Get_Player_Coordinate.player1Y;

       transform.position = new Vector3(player1XOnUnity,0, player1YOnUnity);


        
    }
}
