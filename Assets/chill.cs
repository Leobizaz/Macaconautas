using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "inimigoBloco")
        {
            other.GetComponent<NavMeshAgent>().speed = 5;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "inimigoBloco")
        {
            other.GetComponent<NavMeshAgent>().speed = 10;
        }
    }
}
