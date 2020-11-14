using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemyAI : MonoBehaviour
{
    public GameObject enemy;
    public NavMeshAgent enemyNavMesh;
    public GameObject[] playerpos;


    void Start()
    {
        playerpos = GameObject.FindGameObjectsWithTag("Player");
        enemy = this.gameObject;
        enemyNavMesh = GetComponent<NavMeshAgent>();
        
    }

   
    void FixedUpdate()
    {

        for (int i = 0; i < playerpos.Length; i++)
        {


            float lowestSoFar = Mathf.Infinity;

            float currentDistanceToEnemy = Vector3.Distance(transform.position, playerpos[i].transform.position);
            GameObject closest;

            if (currentDistanceToEnemy < lowestSoFar)
            {
                lowestSoFar = currentDistanceToEnemy;
                closest = playerpos[i];

                Vector3 dir = closest.transform.position;
                enemyNavMesh.SetDestination(dir);
            }
        }

        




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            Debug.Log("acertei");
            SimplePool.Despawn(enemy);
        }
    }

}
