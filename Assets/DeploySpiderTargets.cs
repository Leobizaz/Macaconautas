using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploySpiderTargets : MonoBehaviour
{
    public GameObject[] targets;

    private void Start()
    {
        foreach(GameObject target in targets)
        {
            target.transform.parent = null;
        }
    }
}
