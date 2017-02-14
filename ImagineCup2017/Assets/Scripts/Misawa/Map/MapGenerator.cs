﻿using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

    int[,] groundData = { 
//     ○ ←カメラはこの位置

        {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3, },
        {3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3, },
        {3,3,3,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,3, },
        {3,3,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,3, },
        {3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3, },
        {3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3, },
    };

    [SerializeField, Tooltip("地面に貼るマテリアル")]
    Material[] groundMaterials;

    [SerializeField]
    GameObject groundParent;

    [SerializeField]
    GameObject[] itemParticles;
    /*
    どこにどのビルがあるかの情報
    工場の種類は　”(マップに入ってる値 - 1) / 5”　で求める
    0  :工場A or 工場なし
    1  :工場B
    2  :工場C
    3  :工場D
    4  :工場E
    ランクは　”(マップに入ってる値 % 5) - maxRank”　で求める
    -1 :工場なし
    0  :ランク1
    1  :ランク2
    2  :ランク3
    3  :ランク4
    4  :ランク5
    */
    int[,] buildingData = { 
//     ○ ←カメラはこの位置
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, },
    };

    [SerializeField]
    int maxRank;

    //建てた建物のオブジェクトを持っておく配列
    GameObject[,] buildingObjects;
    //建てた建物のオブジェクトを持っておく配列
    ParticleSystem[,] particleObjects;

    [SerializeField, Tooltip("地面に貼るマテリアル")]
    Material[] buildingMaterials;

    [SerializeField]
    GameObject buildingParent;

    [SerializeField]
    Material choiceCubeMaterials;

    //[SerializeField]
    GameObject choiceCube;

    // Use this for initialization
    void Start()
    {
        choiceCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        choiceCube.transform.position = new Vector3(0, 1000, 0);
        choiceCube.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        choiceCube.GetComponent<Renderer>().material = choiceCubeMaterials;


        for (int i = 0;i < groundData.GetLength(0); i++)
        {
            for (int j = 0; j < groundData.GetLength(1); j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(i,0,j);
                cube.GetComponent<Renderer>().material = groundMaterials[groundData[i,j]];
                cube.transform.SetParent(groundParent.transform);
            }
        }

        //建てた建物のオブジェクトを持っておく配列を初期化
        buildingObjects = new GameObject[buildingData.GetLength(0), buildingData.GetLength(1)];
        particleObjects = new ParticleSystem[buildingData.GetLength(0), buildingData.GetLength(1)];
        for (int i = 0; i < buildingData.GetLength(0); i++)
        {
            for (int j = 0; j < buildingData.GetLength(1); j++)
            {
                buildingObjects[i,j] = null;
                particleObjects[i, j] = null;
            }
        }

        //マップチップに合わせて建物を生成
        for (int i = 0; i < buildingData.GetLength(0); i++)
        {
            for (int j = 0; j < buildingData.GetLength(1); j++)
            {
                if (buildingData[i, j] == 1) {
                    GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                    quad.transform.position = new Vector3(i - 0.25f, 1.0f, j - 0.25f);
                    quad.transform.rotation = Quaternion.Euler(45, 45, 0);
                    quad.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                    quad.GetComponent<Renderer>().material = buildingMaterials[buildingData[i, j]-1];

                    //Particleの生成
                    GameObject particle = Instantiate(itemParticles[0]) as GameObject;
                    particle.transform.SetParent(quad.transform);
                    particle.transform.localPosition = Vector3.zero;
                    particle.transform.rotation = Quaternion.Euler(-45, -45, 0);
                    ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();

                    quad.transform.SetParent(buildingParent.transform);

                    //作ったオブジェクトを配列に登録
                    buildingObjects[i, j] = quad;
                    particleObjects[i, j] = particleSystem;
                }
            }
        }

    }

    /// <summary>
    /// 工場をたてる
    /// </summary>
    /// <param name="factoryID">建てたい工場のID</param>
    /// <returns>建てるのに成功したか</returns>
    public bool CreateBuilding(int factoryID)
    {
        GameObject hitObj = RayCast();

        if (hitObj == null) return false;
        Debug.Log(hitObj.tag);
        if (hitObj.tag == "IndustryTab" || hitObj.tag == "HoldTab") return false;

        choiceCube.transform.position = hitObj.transform.position;

        int x = (int)choiceCube.transform.position.x;
        int y = (int)choiceCube.transform.position.z;

        if (buildingData[x, y] != 0) return false;

        buildingData[x, y] = (factoryID* maxRank) +1;
        GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.transform.position = new Vector3(x - 0.25f, 1.0f, y - 0.25f);
        quad.transform.rotation = Quaternion.Euler(45, 45, 0);
        quad.transform.localScale = new Vector3(1.2f, 1.2f, 0);
        quad.GetComponent<Renderer>().material = buildingMaterials[buildingData[x, y] - 1];

        //Particleの生成
        GameObject particle = Instantiate(itemParticles[0]) as GameObject;
        particle.transform.SetParent(quad.transform);
        particle.transform.localPosition = Vector3.zero;
        particle.transform.localRotation = Quaternion.Euler(-25, -180, 0);
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();

        quad.transform.SetParent(buildingParent.transform);

        //作ったオブジェクトを配列に登録
        buildingObjects[x, y] = quad;
        particleObjects[x, y] = particleSystem;
        return true;
    }

    /// <summary>
    /// 工場のランクを上げる
    /// </summary>
    /// <returns>ランクを上げることに成功したか</returns>
    public bool RankUpBuilding()
    {
        GameObject hitObj = RayCast();

        if (hitObj == null) return false;

        choiceCube.transform.position = hitObj.transform.position;

        int x = (int)choiceCube.transform.position.x;
        int y = (int)choiceCube.transform.position.z;
        Debug.Log(buildingData[x, y]);
        if (buildingData[x, y] <= 0) return false;
        if ((buildingData[x, y] % maxRank) - 1 >= 2 || ((buildingData[x, y] % maxRank) - 1) < 0) return false;

        buildingData[x, y]++;
        buildingObjects[x, y].GetComponent<Renderer>().material = buildingMaterials[buildingData[x, y] - 1];
        return true;
    }

    private GameObject RayCast()
    {
        //カメラの場所からポインタの場所に向かってレイを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        //レイが何か当たっているかを調べる
        if (Physics.Raycast(ray, out hit))
        {
            return (hit.collider.gameObject);
        }
        return null;
    }

    public int GetThisFactoryRank()
    {
        GameObject hitObj = RayCast();

        if (hitObj == null) return -1;

        choiceCube.transform.position = hitObj.transform.position;

        int x = (int)choiceCube.transform.position.x;
        int y = (int)choiceCube.transform.position.z;
        Debug.Log("工場ランク = "+((buildingData[x, y] - 1) % maxRank));
        return ((buildingData[x, y] - 1) % maxRank);
    }

    public int GetThisFactoryID()
    {
        GameObject hitObj = RayCast();

        if (hitObj == null) return -1;

        choiceCube.transform.position = hitObj.transform.position;

        int x = (int)choiceCube.transform.position.x;
        int y = (int)choiceCube.transform.position.z;
        Debug.Log("工場ID = " + (buildingData[x, y] - 1) / maxRank);

        if (buildingData[x, y] == 0) return -1;

        return (buildingData[x, y] - 1) / maxRank;
    }

    public void PlayParticle()
    {
        for(int i = 0;i<particleObjects.GetLength(0);i++)
        {
            for (int j = 0; j < particleObjects.GetLength(1); j++)
            {
                if (particleObjects[i, j] != null)
                {
                    particleObjects[i, j].Play();
                }
            }
        }
    }
}
