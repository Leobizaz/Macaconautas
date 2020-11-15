using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrapManager : MonoBehaviour
{
    public GameObject scrapPrefab;

    public float scrapTotal = 0;
    public Text textRef;
    public int ScrapCount;

    public Transform[] spawns;

    public int scrapWave;
    public int IsRuning = 1;

    private float SpawnRangex;
    private float SpawnRangez;
    public float minSpawnx;
    public float maxSpawnx;
    public float minSpawnz;
    public float maxSpawnz;

    public Transform playerPosForSpawn;

    void Start()
    {
        playerPosForSpawn = GameObject.FindGameObjectWithTag("Core").transform;
        SimplePool.Preload(scrapPrefab, ScrapCount);
        textRef = GetComponentInChildren<Text>();

    }

   
    void FixedUpdate()
    {
        if(IsRuning == 1)
        {

            StartCoroutine(spawnScrap());

        }
    }

    public void addScore(float value)
    {
        scrapTotal += value;
        textRef.text = scrapTotal.ToString();

    }

    IEnumerator spawnScrap()
    {
        IsRuning = 0;


        for (int i = 0; i < ScrapCount; i++)
        {

            SpawnRangex = Random.Range(minSpawnx, maxSpawnx);
            SpawnRangez = Random.Range(minSpawnz, maxSpawnz);
            Vector3 randomPoint = new Vector3(playerPosForSpawn.position.x + SpawnRangex, playerPosForSpawn.position.y, playerPosForSpawn.position.z + SpawnRangez);

            GameObject spawnPoint = new GameObject();
            spawnPoint.transform.position = randomPoint;
            SimplePool.Spawn(scrapPrefab, spawnPoint.transform.position, Quaternion.identity);
            Destroy(spawnPoint);
        }


        yield return new WaitForSeconds(scrapWave);
        IsRuning = 1;

    }

}
