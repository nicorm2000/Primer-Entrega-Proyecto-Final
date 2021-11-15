using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTimeado : MonoBehaviour
{
    public GameObject[] spawnerArray;
    [SerializeField] GameObject[] enemyPrefabs;
    private GameObject spawner;
    [SerializeField] float startDelay = 3f;
    [SerializeField] float spawnInterval = 6f;
    private GameObject spawningZone;
    private GameObject player;
    private Transform distancia;
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
        spawningZone = GameObject.FindWithTag("SpawningZone");
        player = GameObject.FindWithTag("Player");
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        float dist = Vector3.Distance(player.transform.position, spawner.transform.position);
        if (dist < 50f)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], transform.position, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}
