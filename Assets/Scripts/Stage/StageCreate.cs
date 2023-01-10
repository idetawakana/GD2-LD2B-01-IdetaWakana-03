using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class StageCreate : MonoBehaviour
{
    private StageSet stageSet;

    public float[,] stage;

    public Vector3 pos;

    private bool isCreate;

    public GameObject floor;
    public GameObject floorP;
    public GameObject block;

    public CameraPos cameraPos;

    public float cameraX;

    public float cameraY;

    // Start is called before the first frame update
    void Start()
    {
        stageSet = GetComponent<StageSet>();

        GameObject cameraObj = GameObject.Find("Main Camera");
        cameraPos = cameraObj.GetComponent<CameraPos>();

        isCreate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCreate == false)
        {
            stage = stageSet.stage;

            for (int i = 0; i < stage.GetLength(0); i++)
            {
                for (int j = 0; j < stage.GetLength(1); j++)
                {
                    pos = new Vector3(j/* - (stage.GetLength(1) / 2)*/, -i/* + stage.GetLength(0) / 2*/, 0);

                    if (stage[i, j] == 1)
                    {
                        Instantiate(floor, pos, Quaternion.identity);
                    }
                    if (stage[i, j] == 2)
                    {
                        Instantiate(floorP, pos, Quaternion.identity);
                    }
                    if (stage[i, j] == 3)
                    {
                        Instantiate(block, pos, Quaternion.identity);
                    }
                }
            }

            cameraX = stage.GetLength(0) / 2;
            cameraY = stage.GetLength(1) / 2;

            cameraPos.SetCamera(cameraX,cameraY);

            isCreate = true;
        }
    }
}
