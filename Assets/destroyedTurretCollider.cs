using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyedTurretCollider : MonoBehaviour
{
    public GameObject storeRef;
    public float ScrapValue;
    public bool hasBoght = false;
    public int IsRuning = 1;
    private void Start()
    {
        //storeRef = GameObject.FindGameObjectWithTag("Scrapstore");
    }

    private void FixedUpdate()
    {
        if (IsRuning == 1)
            StartCoroutine(check());


        if (storeRef.activeInHierarchy)
            GetComponent<BoxCollider>().gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torre"))
        {
            if (!storeRef.activeInHierarchy && !hasBoght)
                storeRef.SetActive(true);

            SimplePool.Despawn(this.gameObject);
        }
    }

     IEnumerator check()
    {
        IsRuning = 0;

        yield return new WaitForSeconds(3);

        if (!storeRef.activeInHierarchy)
            GetComponent<BoxCollider>().gameObject.SetActive(true);

        IsRuning = 1;
    }
}
