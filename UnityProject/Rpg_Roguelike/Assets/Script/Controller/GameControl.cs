using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject player;
    public Scene battleScene;
    public GameObject Canvas;
	void Start ()
    {
        
	}
	
	void Update ()
    {


        if (battleScene.isLoaded)
        {
            player.SetActive(false);
            Canvas.SetActive(false);
        }
        else
        {
            player.SetActive(true);
            Canvas.SetActive(true);
        }
    }

    public void RandomEncounter()
    {
        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        
        battleScene = SceneManager.GetSceneByName("Battle");
        SceneManager.SetActiveScene(battleScene);
    }

}
