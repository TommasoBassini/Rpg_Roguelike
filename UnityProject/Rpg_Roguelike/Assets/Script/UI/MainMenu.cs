using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
}
