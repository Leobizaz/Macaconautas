using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawns;
    public Transform simpleSpawn;
    public int enemyCount;
    public bool isDay;

    public Transform playerPosForSpawn;

    public float SpawnRangex;
    public float SpawnRangez;
    public float minSpawn;
    public float maxSpawn;

    public int numeberOfSeconds;
    public int IsRuning = 1;
    
    void Start()
    {
        playerPosForSpawn = GameObject.FindGameObjectWithTag("Player").transform;
        SimplePool.Preload(enemyPrefab, enemyCount);

         StartCoroutine(spawner());

        
    }

    private void FixedUpdate()
    {
        if(IsRuning == 1)
        {
            StartCoroutine(spawner());

        }

    }


    IEnumerator  spawner()
    {
        IsRuning = 0;
        

        for (int i = 0; i < enemyCount; i++)
        {

            SpawnRangex = Random.Range(minSpawn, maxSpawn);
            SpawnRangez = Random.Range(minSpawn, maxSpawn);
            Vector3 randomPoint = new Vector3(playerPosForSpawn.position.x + SpawnRangex, 6, playerPosForSpawn.position.z + SpawnRangez);

            GameObject spawnPoint = new GameObject();
            spawnPoint.transform.position = randomPoint;
            SimplePool.Spawn(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            Destroy(spawnPoint);
        }


        yield return new WaitForSeconds(numeberOfSeconds);
        IsRuning = 1;

    }


}
