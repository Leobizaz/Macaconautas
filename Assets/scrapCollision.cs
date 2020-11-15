using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrapCollision : MonoBehaviour
{

    public scrapManager canvasRef;
    public float ScrapValue;
    

    private void Start()
    {
        canvasRef = FindObjectOfType<scrapManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasRef.addScore(ScrapValue);
            SimplePool.Despawn(this.gameObject);
        }
    }

    
}
