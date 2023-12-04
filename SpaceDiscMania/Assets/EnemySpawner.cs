using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject bossPrefab;

    [SerializeField]
    private float enemyInterval = 5f;
    [SerializeField]
    private float bossInterval = 10f;
    [SerializeField]
    private int maxEnemysInGame = 30;
    public int currentEnemys;

    void Start()
    {
        currentEnemys = 0;
        StartCoroutine(spawnEnemys(enemyInterval, enemyPrefab));
        StartCoroutine(spawnEnemys(bossInterval, bossPrefab));
    }

    private IEnumerator spawnEnemys(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        
        GameObject newEnemy = Instantiate(enemy, this.transform.position, Quaternion.identity);
        currentEnemys++;

        if(currentEnemys != maxEnemysInGame)
        {
            StartCoroutine(spawnEnemys(interval, enemy));
        }
    }
}
