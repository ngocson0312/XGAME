using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawn groundSpawn;
    [SerializeField] GameObject[] ObstanclesPrefabs;
    [SerializeField] GameObject coinPrefabs;
    [SerializeField] GameObject CoinSpeed ;

    //enemy

    public GameObject enemy;
    public Transform[] spawnPos;
    public float spawnTime = 80;
    private float time = 0;
    public  bool spawn =true;
    public static bool spawnnn;
    void Update()
    {
        if(GameManager.inst.scores >5 && GameManager.inst.scores<18)
        {
            EnemySpawn();
        }
      
         
    }


    public void EnemySpawn()
    {
        if (time > spawnTime)
        {
            int index = Random.Range(0, 3);
            GameObject ob = Instantiate(enemy, spawnPos[index]);

            Destroy(ob, 220f);
            time = 0;
        }
        time += Time.deltaTime * 0.5f;

    }
    private void Start()
    {
        if (GameManager.inst.scores < 16)
        {
            groundSpawn = GameObject.FindObjectOfType<GroundSpawn>();
            SpawnCoins();
            SpawnCoinSpeed();
            SpawnObstancle();
            EnemySpawn();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (GameManager.inst.scores < 16)
        {
            groundSpawn.SpawnTile(true,GroundSpawn.map);
        } else
        {
            groundSpawn.SpawnTile(false, GroundSpawn.map);

        }
        Destroy(gameObject, 2f);
    }

    public void SpawnObstancle()
    {
        int index = Random.Range(0, 3);

        int ObstancleSpawnPosition = Random.Range(2, 7);

        Transform spawnPoint = transform.GetChild(ObstancleSpawnPosition).transform;

        Instantiate(ObstanclesPrefabs[index], spawnPoint.position, Quaternion.identity, transform);

    }
    public void SpawnCoins()
    {
        int coinsSpawn = 3;
        for (int i = 0; i < coinsSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefabs ,transform);
            temp.transform.position = GetRandomCoin(GetComponent<Collider>());
        }
    }

    public void SpawnCoinSpeed()
    {
        int coinsSpawn = 1;
        for (int i = 0; i < coinsSpawn; i++)
        {
            GameObject temp = Instantiate(CoinSpeed, transform);
            temp.transform.position = GetRandomCoin(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomCoin(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x ,collider.bounds.max.x),
             Random.Range(collider.bounds.min.y, collider.bounds.max.y),
              Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );

        if(point != collider .ClosestPoint(point))
        {
            point = GetRandomCoin(collider);
        }

        point.y = 1;
        return point;
    }
}
