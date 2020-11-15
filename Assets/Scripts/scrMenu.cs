using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scrMenu : MonoBehaviour
{
    public void QuitGame() {
        Application.Quit();
    }
    public void GoMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void GoGame()
    {
        SceneManager.LoadScene("CenaPrincipal01");
    }
}
