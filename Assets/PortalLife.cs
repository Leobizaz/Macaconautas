using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLife : MonoBehaviour
{
    public int maxHp = 30;
    [SerializeField] int currentHP;
    bool once;

    private void Start()
    {
        currentHP = maxHp;
    }

    private void Update()
    {
        if(currentHP <= 0 && !once)
        {
            once = true;
            GameManager.portalDestroyed++;
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        currentHP--;
    }
}
