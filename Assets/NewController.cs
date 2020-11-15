using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NewController : MonoBehaviour
{
    NavMeshAgent agent;
    public LayerMask layerMask;
    public bool active;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        
    }

    private void Update()
    {
        if (active)
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, layerMask))
                {
                    agent.destination = hit.point;
                }
            }
        }
    }
}
