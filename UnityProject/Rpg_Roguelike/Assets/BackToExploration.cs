using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BackToExploration : MonoBehaviour
{

    void Start()
    {
        Invoke("ReturnBackToMainMenu", 4);
    }


    void ReturnBackToMainMenu()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("ProvaTommy"));
        SceneManager.UnloadScene(1);
    }
}
