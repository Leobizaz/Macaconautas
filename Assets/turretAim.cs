using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretAim : MonoBehaviour
{
    public Transform target;
    public float range = 15f;
    public string enemyTag;

    public Transform partToRotateReference;

    public int turnSpeed = 3;

    // shooting
    public ParticleSystem tiro;
    public float fireRate = 1f;
    private float fireCountdown = 0f;


    void Start()
    {
        InvokeRepeating("updateTarget", 0f, 0.2f);
    }

    void updateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;


            }


        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }
    
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation =  Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotateReference.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotateReference.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

        //shooting

        if(fireCountdown <= 0f)
        {
            Shoot();
            tiro.Play();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        Debug.Log("SHIET!");

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
