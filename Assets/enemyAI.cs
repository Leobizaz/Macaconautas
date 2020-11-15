using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyAI : MonoBehaviour
{
    public GameObject enemy;
    public NavMeshAgent enemyNavMesh;
    public GameObject[] playerpos;
    public GameObject playerpos2;
    //public Vector3 dir;

    private float lowestSoFar = Mathf.Infinity;
    public GameObject closest;
    public float r;
    
    public int numeberOfSeconds;
    public int IsRuning = 1;

    private void Awake()
    {

        r = Random.Range(0, 99);
        playerpos = GameObject.FindGameObjectsWithTag("Torre");
        playerpos2 = GameObject.FindGameObjectWithTag("Core");
        enemy = this.gameObject;
        enemyNavMesh = GetComponent<NavMeshAgent>();
        lowestSoFar = Mathf.Infinity;
        StartCoroutine(setDestinationCoroutine());

        

    }

   
        

    

   
    void FixedUpdate()
    {
        if(IsRuning == 1 && r < 60)       
        StartCoroutine(setDestinationCoroutine());
        else
            StartCoroutine(setDestinationCoroutine2());

        if (closest.activeInHierarchy)
        enemyNavMesh.SetDestination(closest.transform.position);
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torre") || other.CompareTag("Core"))
        {

            other.GetComponent<hpbar>().modifyHealth(-1);
            SimplePool.Despawn(enemy);
        }
    }

    public IEnumerator setDestinationCoroutine()
    {
        IsRuning = 0;

        

        for (int i = 0; i < playerpos.Length; i++)
        {
            float currentDistanceToEnemy = Vector3.Distance(transform.position, playerpos[i].transform.position);

            if (currentDistanceToEnemy < lowestSoFar)
            {
                lowestSoFar = currentDistanceToEnemy;
                closest = playerpos[i];
            }         
        }
      
     
        yield return new WaitForSeconds(numeberOfSeconds);
        IsRuning = 1;
    }

    public IEnumerator setDestinationCoroutine2()
    {
        IsRuning = 0;

               closest = playerpos2;

        yield return new WaitForSeconds(numeberOfSeconds);
        IsRuning = 1;
    }

}
