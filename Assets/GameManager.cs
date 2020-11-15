using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;

    private void Start()
    {
        GameEvents.current.onGameOver += CheckGameOver;
    }

    void CheckGameOver(string result)
    {
        if(result == "Win")
        {
            winScreen.SetActive(true);
            return;
        }

        if(result == "Lose")
        {
            loseScreen.SetActive(true);
        }
    }


}
