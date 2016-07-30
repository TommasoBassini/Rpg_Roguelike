using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject player;
    public Scene battleScene;
    public GameObject Canvas;
    public GameObject cameraOBJ;

	
	void Update ()
    {


        if (battleScene.isLoaded)
        {
            cameraOBJ.SetActive(false);
            player.SetActive(false);
            Canvas.SetActive(false);
        }
        else
        {
            cameraOBJ.SetActive(true);
            player.SetActive(true);
            Canvas.SetActive(true);
        }
    }

    public void RandomEncounter(Vector2 pos)
    {
        PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
        if (((int)pos.x >= 0 && (int)pos.x < 47) && ((int)pos.y >= 0 && (int)pos.y <= 18))
        {
            stats.livelloNemici = 2;
            stats.nzona = 0;
        }
        else if (((int)pos.x >= 0 && (int)pos.x < 44) && ((int)pos.y >= 19 && (int)pos.y <= 38))
        {
            stats.livelloNemici = 4;
            stats.nzona = 0;
        }
        else if (((int)pos.x >= 0 && (int)pos.x < 44) && ((int)pos.y >= 39 && (int)pos.y <= 64))
        {
            stats.livelloNemici = 6;
            stats.nzona = 0;
        }
        else if (((int)pos.x >= 0 && (int)pos.x < 35) && ((int)pos.y >= 65 && (int)pos.y <= 99))
        {
            stats.livelloNemici = 4;
            stats.nzona = 1;
        }
        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        battleScene = SceneManager.GetSceneByName("Battle");
        SceneManager.SetActiveScene(battleScene);
    }
}
