using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public event Action onSelectTower;
    public event Action<GameObject> onCreateTower;
    public event Action<GameObject> onDestroyTower;
    public event Action<string> onGameOver;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        
    }

    public void GameOver(string result)
    {
        if(onGameOver != null)
        {
            onGameOver(result);
        }
    }

    public void CreateTower(GameObject tower)
    {
        if(onCreateTower != null)
        {
            onCreateTower(tower);
        }
    }
    public void DestroyTower(GameObject tower)
    {
        if(onDestroyTower != null)
        {
            onDestroyTower(tower);
        }
    }

    public void selectTower()
    {
        if(onSelectTower != null)
        {
            onSelectTower();
        }
    }


}
