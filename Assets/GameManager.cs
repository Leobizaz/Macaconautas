using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int portalDestroyed = 0;
    public GameObject winScreen;
    public GameObject loseScreen;

    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;

    float timeElapsed;


    private void Start()
    {
        portalDestroyed = 0;
        GameEvents.current.onGameOver += CheckGameOver;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (portalDestroyed >= 4) winScreen.SetActive(true);
        
        if(timeElapsed > 60)
        {
            portal1.SetActive(true);
            GameEvents.current.NewPortal();
        }

        if(timeElapsed > 220)
        {
            portal2.SetActive(true);
            GameEvents.current.NewPortal();
        }
        if(timeElapsed > 560)
        {
            portal3.SetActive(true);
            GameEvents.current.NewPortal();
        }
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
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
