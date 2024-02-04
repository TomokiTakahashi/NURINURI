using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///どのアイテムを生成するのかをランダムに振り分けるためのプログラム
//０のときアイテムを生成し、１のときはアイテムを生成しない。

public class Item : MonoBehaviour
{
    public static bool itemExist;
    public int  playerSwitch;
    public int itemKind;
    

    public int itemXOnUnity;
    public int itemYOnUnity;

    public int itemXOnArray;
    public int itemYOnArray;

    public static bool bomSwitch;
    public static bool darumaSwitch;
    public static bool kemuriSwitch;

    private int itemCreateTime;

    public GameObject Bom;
    public GameObject Daruma;
    public GameObject Kemuri;

    // Start is called before the first frame update
    void Start()
    {
        itemExist=false;
        itemCreateTime=100;
    }

    //アイテムを作るための関数。出現するアイテムの種類、どちらのプレイヤー側に出現するのかをランダムに決める
    void CreateItems(){

        itemCreateTime=200;
        itemKind=Random.Range(2,3);
        playerSwitch=Random.Range(1,3);
    
        if(itemKind==0){
            bomSwitch=true;
        }else if(itemKind==1){
            kemuriSwitch=true;
        }else if(itemKind==2){
            darumaSwitch=true;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
        if(itemExist==false){
            if(itemCreateTime>0){
                itemCreateTime-=1;
            }else{
                CreateItems();
                itemExist=true;
            }
        }

        if(bomSwitch==true){
            Bom.SetActive(true);
        }else{
            Bom.SetActive(false);
        }

        if(kemuriSwitch==true){
            Kemuri.SetActive(true);
        }else{
            Kemuri.SetActive(false);
        }

        if(darumaSwitch==true){
            Daruma.SetActive(true);
        }else{
            Daruma.SetActive(false);
        }
    }
}

 