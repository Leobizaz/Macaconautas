using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ECM.Controllers;
using ECM.Components;

public class TowerSelector : MonoBehaviour
{
    public NewController towerAgent;
    Ray ray;
    public LayerMask layerMask;
    public GameObject decal;

    public AudioSource sfxRandomSound;
    public AudioClip[] audioSources;

    private void Start()
    {
        GameEvents.current.onSelectTower += DeSelectTower;
    }

    public void DeSelectTower()
    {
        towerAgent.active = false;
        decal.SetActive(false);
    }

    public void SelectTower()
    {
        towerAgent.active = true;
        decal.SetActive(true);
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
                    /* if(audioSources != null){
                        sfxRandomSound.clip = audioSources[Random.Range(0, 1)];
                        sfxRandomSound.Play();
                    }
                    */
                    GameEvents.current.selectTower();
                    SelectTower();
                }

                Debug.Log("Encostou");
            }
            else
            {
                DeSelectTower();
            }
        }
    }

}
