using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public event Action onSelectTower;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        
    }

    public void selectTower()
    {
        if(onSelectTower != null)
        {
            onSelectTower();
        }
    }


}
