using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private GameObject spawner;
    public float startDelay = 2;
    public float spawnInterval = 1.5f;
    public int enemySpawnerCount = 3;
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
        //if (enemySpawnerCount > 1)
        //{
            InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
        //}
        //else
        //{
        //    Destroy(spawner);
        //    enemySpawnerCount = 0;
        //}

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        //enemySpawnerCount -= 1;
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], transform.position, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
