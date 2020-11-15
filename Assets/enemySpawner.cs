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

    public GameObject[] SpawnPortal;

    private float SpawnRangex;
    private float SpawnRangez;
    public float minSpawnx;
    public float maxSpawnx;
    public float minSpawnz;
    public float maxSpawnz;

    public int waveTimer;
    public int IsRuning = 1;
    
    void Start()
    {

        SpawnPortal = GameObject.FindGameObjectsWithTag("Portal");
           
        SimplePool.Preload(enemyPrefab, enemyCount* SpawnPortal.Length);

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
        

        for (int i = 0; i < SpawnPortal.Length; i++)
        {

            SpawnRangex = Random.Range(minSpawnx, maxSpawnx);
            SpawnRangez = Random.Range(minSpawnz, maxSpawnz);
            Vector3 randomPoint = new Vector3(SpawnPortal[i].transform.position.x + SpawnRangex, SpawnPortal[i].transform.position.y, SpawnPortal[i].transform.position.z + SpawnRangez);

            GameObject spawnPoint = new GameObject();
            spawnPoint.transform.position = randomPoint;
            for (int z = 0; z < enemyCount; z++)
            {
                SimplePool.Spawn(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                Destroy(spawnPoint);
            }
            
        }


        yield return new WaitForSeconds(waveTimer);
        IsRuning = 1;

    }


}
