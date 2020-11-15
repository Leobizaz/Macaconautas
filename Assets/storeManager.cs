using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class storeManager : MonoBehaviour
{
    public GameObject dpsPrefab;
    public GameObject tankPrefab;
    public GameObject supportPrefab;

    private destroyedTurretCollider destroyedRef;

    public scrapManager scrapRef;

    public GameObject coreRef;

    public float CostTurret;

    void Start()
    {
        scrapRef = FindObjectOfType<scrapManager>();
        coreRef = GameObject.FindGameObjectWithTag("Core");
        destroyedRef = FindObjectOfType<destroyedTurretCollider>();
    }

    public void DPSButton()
    {
        if(scrapRef.scrapTotal >= CostTurret)
        {
            Vector3 doladin = new Vector3(coreRef.transform.position.x + 2, coreRef.transform.position.y, coreRef.transform.position.z + 2);
            var torre = Instantiate(dpsPrefab, coreRef.transform.position + doladin, Quaternion.identity);
            torre.transform.parent = null;
            GameEvents.current.CreateTower(torre);
            destroyedRef.hasBoght = true;
            this.gameObject.SetActive(false);
        }

    }

    public void TankButton()
    {
        if (scrapRef.scrapTotal >= CostTurret)
        {
            Vector3 doladin = new Vector3(coreRef.transform.position.x + 2, coreRef.transform.position.y, coreRef.transform.position.z + 2);
            var torre = Instantiate(tankPrefab, coreRef.transform.position + doladin, Quaternion.identity);
            torre.transform.parent = null;
            GameEvents.current.CreateTower(torre);
            destroyedRef.hasBoght = true;
            this.gameObject.SetActive(false);
        }

    }

    public void SupportButton()
    {
        if (scrapRef.scrapTotal >= CostTurret)
        {
            Vector3 doladin = new Vector3(coreRef.transform.position.x + 2, coreRef.transform.position.y, coreRef.transform.position.z + 2);
            var torre = Instantiate(supportPrefab, coreRef.transform.position + doladin, Quaternion.identity);
            torre.transform.parent = null;
            GameEvents.current.CreateTower(torre);
            destroyedRef.hasBoght = true;
            this.gameObject.SetActive(false);
        }

    }

    public void ExitButton()
    {
        this.gameObject.SetActive(false);
    }


}
