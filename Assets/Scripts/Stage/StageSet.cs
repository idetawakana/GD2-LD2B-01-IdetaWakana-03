using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSet : MonoBehaviour
{
    //0→何もない(プレイヤーの移動の制御に使う)　1→床　2→プレイヤーが動ける床　3→ブロック
    public float[,] stage = new float[,]
{
        {0,0,0,0,0,0,0,0,0},
        {0,1,1,1,1,1,1,1,0},
        {0,1,1,1,1,1,1,1,0},
        {0,1,1,2,1,3,1,1,0},
        {0,2,2,2,2,2,2,2,0},
        {0,1,1,1,1,1,1,1,0},
        {0,1,1,1,3,1,1,1,0},
        {0,1,1,1,1,1,1,1,0},
        {0,0,0,0,0,0,0,0,0}
};

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
