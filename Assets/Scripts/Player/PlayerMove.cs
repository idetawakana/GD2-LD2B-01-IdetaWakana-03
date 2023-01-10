using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private StageCreate stageCreate;

    private Vector3 pos;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GameObject stageObj = GameObject.Find("Stage");
        stageCreate = stageObj.GetComponent<StageCreate>();

        transform.position = new Vector3(4, -4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    pos.y += speed;
        //}

        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    pos.y -= speed;
        //}


        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (stageCreate.stage[-Mathf.RoundToInt(pos.y), Mathf.RoundToInt(pos.x) - 1] == 2)
            {
                pos.x -= speed;
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (stageCreate.stage[-Mathf.RoundToInt(pos.y), Mathf.RoundToInt(pos.x) + 1] == 2)
            {
                pos.x += speed;
            }
        }

        transform.position = pos;
    }
}
