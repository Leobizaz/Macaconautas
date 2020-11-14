using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using ECM.Components;

public class TowerSelector : MonoBehaviour
{
    public BaseAgentController towerAgent;
    Ray ray;
    public LayerMask layerMask;
    private void Start()
    {
        GameEvents.current.onSelectTower += onTowerSelected;
    }

    void onTowerSelected()
    {
        towerAgent.GetComponent<CharacterMovement>().enabled = false;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 999, layerMask, QueryTriggerInteraction.Collide))
            {

                if(hit.transform.gameObject == this.transform.parent.gameObject)
                {
                    Debug.Log("Tower selected");
                    GameEvents.current.selectTower();
                    //towerAgent.enabled = true;
                    towerAgent.agent.isStopped = false;
                    towerAgent.agent.speed = 5;
                    towerAgent.GetComponent<CharacterMovement>().enabled = true;
                }

                Debug.Log("Encostou");
            }
        }
    }

}
