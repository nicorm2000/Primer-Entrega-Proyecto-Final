using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTimeado : MonoBehaviour
{
    public GameObject[] spawnerArray;
    public GameObject[] enemyPrefabs;
    private GameObject spawner;
    private GameObject spawner1;
    private GameObject spawner2;
    [SerializeField] float startDelay = 3f;
    [SerializeField] float spawnInterval = 6f;
    private GameObject spawningZone;
    private GameObject player;
    private Transform distancia;
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
        spawner1 = GameObject.FindWithTag("Spawner1");
        spawner2 = GameObject.FindWithTag("Spawner2");
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
        float dist1 = Vector3.Distance(player.transform.position, spawner1.transform.position);
        if (dist1 < 50f)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], transform.position, enemyPrefabs[enemyIndex].transform.rotation);
        }
        float dist2 = Vector3.Distance(player.transform.position, spawner2.transform.position);
        if (dist2 < 50f)
        {
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], transform.position, enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
}
