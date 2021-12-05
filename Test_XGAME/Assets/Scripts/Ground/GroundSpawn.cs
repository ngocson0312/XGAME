using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    
    public GameObject[] GroundTile;
    Vector3 NextSpawnPoint;
    public static bool spawn;

    public static int map;
     public void SpawnTile(bool limit,int map)
    {
        
        if (GameManager.inst.scores < 14)
        {
            GameObject temp = Instantiate(GroundTile[map], NextSpawnPoint, Quaternion.identity);
            NextSpawnPoint = temp.transform.GetChild(1).transform.position;
        }
    }

    public void RandomSpawn()
    {
        
        map = Random.Range(0, 3);
        if (map > 2) return;

        if(map == 0)
        {
            SpawnTile(true, map);
        }
        if(map == 1)
        {
            SpawnTile(true, map);

        }
        if (map == 2)
        {
            SpawnTile(true,map);
        }

    }
    void Start()
    {
        
        for (int i = 0; i < 3; i++)
        {
             RandomSpawn();
        }
    }
}
