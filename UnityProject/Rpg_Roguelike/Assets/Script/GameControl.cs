using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject player;
    public Scene battleScene;

	void Start ()
    {
        
	}
	
	void Update ()
    {
        

        if (battleScene.isLoaded)
        {
            player.SetActive(false);
        }
        else
            player.SetActive(true);
    }

    public void RandomEncounter()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        battleScene = SceneManager.GetSceneByName("Battle");
    }

}
