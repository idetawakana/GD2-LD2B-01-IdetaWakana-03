using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer line;

    private PlayerMove player;

    private GameObject box;

    public float speed;

    public bool isHit;

    public bool isExtend;

    public List<Vector3> linePoints; 

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    // Start is called before the first frame update
    void Start()
    {
        linePoints = new List<Vector3>();
        line = GetComponent<LineRenderer>();

        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<PlayerMove>();

        pos1 = player.transform.position;
        //pos1.y += player.transform.localScale.y / 2;

        pos2 = player.transform.position;
        //pos2.y += player.transform.localScale.y / 2;

        linePoints.Add(pos1);
        linePoints.Add(pos1);
        isHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        pos1 = player.transform.position;

        if(isHit == false && isExtend == false)
        {
            pos1 = player.transform.position;
            pos2 = player.transform.position;
            linePoints[0] = pos1;
            linePoints[1] = pos2;
            SetPositions(linePoints);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isHit == true)
            {
                isExtend = false;
                isHit = false;
                pos2 = player.transform.position;
                linePoints[0] = pos1;
                linePoints[1] = pos2;
                SetPositions(linePoints);


            }
            else
            {
                isExtend = true;
            }
        }

        if (isHit == false && isExtend == true)
        {
            pos2.y += speed;
            //ìñÇΩÇËîªíËÇÃê›íË
            linePoints[1] = pos2;
            SetPositions(linePoints);
        }


        /*
        linePoints.Add(pos2);
        line.GetComponent<EdgeCollider2D>().SetPoints(linePoints);

        //í∏ì_Çí«â¡
        positions = new Vector3[]
        { pos1,pos2 };

        //í∏ì_ÇÃêî
        line.positionCount = positions.Length;

        //ê¸ÇèëÇ≠
        line.SetPositions(positions);
        */
    }

    void SetPositions(List<Vector3> positions)
    {
        List<Vector2> positions2D = new List<Vector2>();
        for (int i = 0; i < positions.Count; i++)
        {
            positions2D.Add(new Vector2(positions[i].x, positions[i].y));
        }
        line.GetComponent<EdgeCollider2D>().SetPoints(positions2D);
        line.positionCount = positions.Count;
        line.SetPositions(positions.ToArray());
    }

    private void ResetPoint(List<Vector3> linePoints)
    {
        linePoints[0] = pos1;
        linePoints[1] = pos1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box" || collision.tag == "Block")
        {
            isHit = true;
            box = collision.gameObject;
            pos2.y = box.transform.position.y;
        }
    }
}
