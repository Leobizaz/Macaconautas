using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollider : MonoBehaviour
{
     void OnParticleCollision(GameObject other)
    {
        Debug.Log("colisao");
        Destroy(transform.gameObject);
    }

}
