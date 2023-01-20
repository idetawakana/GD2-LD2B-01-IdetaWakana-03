using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer line;

    private PlayerMove player;

    public float speed;

    public bool isHit;

    public List<Vector2> linePoints; 

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    private Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();

        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<PlayerMove>();

        pos1 = player.transform.position;
        pos1.y += player.transform.localScale.y / 2;

        pos2 = player.transform.position;
        pos2.y += player.transform.localScale.y / 2;

        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isHit == false)
        {
            pos2.y += speed;
        }

        //ワールド座標をリストに追加
        linePoints.Add(pos2);
        //EdgeCollider2Dのポイントを設定
        line.GetComponent<EdgeCollider2D>().SetPoints(linePoints);



        positions = new Vector3[]
        { pos1,pos2 };

        line.positionCount = positions.Length;

        line.SetPositions(positions);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box" || collision.tag == "Block")
        {
            isHit = true;
        }
    }
}
