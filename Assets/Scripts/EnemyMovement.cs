using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speedEnemy;
    private GameObject player;
    private GameObject enemiesPrefab;
    enum EnemiesTypes { Fast, Medium, Slow }
    [SerializeField] private EnemiesTypes enemies;

    private int countSpawner = 200;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        enemiesPrefab = GameObject.FindWithTag("Enemy");
    }

    void Update()
    {
        LookAtPlayer(player);
        switch (enemies)
        {
            case EnemiesTypes.Fast:
                MoveTowards(4f);
                break;
            case EnemiesTypes.Medium:
                MoveTowards(3f);
                break;
            case EnemiesTypes.Slow:
                MoveTowards(2f);
                break;
            default:
                break;
        }
        DestroyEnemies();
    }

    private void MoveTowards(float speed)
    {
        Vector3 direction = player.transform.position - transform.position;
        transform.position += speed * direction.normalized * Time.deltaTime;
    }

    private void LookAtPlayer(GameObject lookObject)
    {
        Vector3 direction = lookObject.transform.position - transform.position;
        Quaternion newQuaternion = Quaternion.LookRotation(direction);
        transform.rotation = newQuaternion;
    }

    private void DestroyEnemies()
    {
        countSpawner -= 1;
        Debug.Log(countSpawner);
        if (countSpawner <= 0)
        {

            Destroy(enemiesPrefab);
        }
    }
}