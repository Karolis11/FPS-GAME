using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints1;
    //[SerializeField] private Transform spawnPoints2;
    //[SerializeField] private Transform spawnPoints3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemiesLevel1()
    {
        for(int i = 0; i < spawnPoints1.Length; ++i)
        {
            Instantiate(enemyPrefab, spawnPoints1[i].transform.position, Quaternion.identity);
        }
    }
}
