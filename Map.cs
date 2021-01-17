using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject groundGo;
    public GameObject playerGo;
    public GameObject stoneGo;

    private void Start()
    {
        GenerateMap(11);
    }

    public void GenerateMap(float size)
    {
        float halfSize = (size - 1) / 2;

        for(int x = 0; x < size; x++)
        {
            for(int z = 0; z < size; z++)
                InstantiateAtPosition(groundGo, new Vector3(x - halfSize, 0, z - halfSize), "ground " + x + " " + z , LayerMask.NameToLayer("Ground"));
            
            InstantiateAtPosition(groundGo, new Vector3(halfSize, 1, x - halfSize), "Wall right " + x, LayerMask.NameToLayer("Wall"));
            InstantiateAtPosition(groundGo, new Vector3(-halfSize, 1, x - halfSize), "Wall left " + x, LayerMask.NameToLayer("Wall"));
            InstantiateAtPosition(groundGo, new Vector3(x - halfSize, 1, -halfSize), "Wall down " + x, LayerMask.NameToLayer("Wall"));
            if (x != halfSize)
                InstantiateAtPosition(groundGo, new Vector3(x - halfSize, 1, halfSize), "Wall up " + x, LayerMask.NameToLayer("Wall"));
        }
        InstantiateAtPosition(playerGo, Vector3.up, "Player");
        InstantiateAtPosition(stoneGo, Vector3.up + Vector3.forward, "Stone");
    }

    private void InstantiateAtPosition(GameObject go, Vector3 pos, string name, int layer = 0)
    {
        GameObject instance = Instantiate(go);
        instance.transform.position = pos;
        instance.layer = layer;
        instance.name = name;
    }
}
