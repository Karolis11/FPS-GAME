using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;

    [SerializeField] private Transform[] spawnPoints1;
    [SerializeField] private Transform[] spawnPoints2;
    [SerializeField] private Transform[] spawnPoints3;

    [SerializeField] private Transform bossSpawnPoint;

    public void SpawnEnemiesLevel1()
    {
        for (int i = 0; i < spawnPoints1.Length; ++i)
        {
            Instantiate(enemyPrefab, spawnPoints1[i].transform.position, Quaternion.identity);
        }
    }

    public void SpawnEnemiesLevel2()
    {
        for (int i = 0; i < spawnPoints2.Length; ++i)
        {
            Instantiate(enemyPrefab, spawnPoints2[i].transform.position, Quaternion.identity);
        }
    }

    public void SpawnEnemiesLevel3()
    {
        for (int i = 0; i < spawnPoints3.Length; ++i)
        {
            Instantiate(enemyPrefab, spawnPoints3[i].transform.position, Quaternion.identity);
        }
        Instantiate(bossPrefab, bossSpawnPoint.transform.position, Quaternion.identity);
    }

    public int GetAmountOfEnemies()
    {
        int enemiesAmount = spawnPoints1.Length + spawnPoints2.Length + spawnPoints3.Length;
        return enemiesAmount;
    }
}
