﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject player;
    public Scene battleScene;
    public GameObject Canvas;
    public GameObject cameraOBJ;
    public bool incontroON;
    public AudioClip ingaggioBattaglia;
    private PlayerStatsControl stats;

    void Start()
    {
        stats = FindObjectOfType<PlayerStatsControl>();
    }

    void Update ()
    {


        if (battleScene.isLoaded)
        {
            incontroON = true;
            player.SetActive(false);
            cameraOBJ.SetActive(false);
            Canvas.SetActive(false);
        }
        else
        {
            UiControlExploration ui = FindObjectOfType<UiControlExploration>();
            incontroON = false;
            player.SetActive(true);
            Canvas.SetActive(true);
            cameraOBJ.SetActive(true);
            if (stats.death)
            {
                stats.SetPlayerPos();
            }
            
            Animator anim = cameraOBJ.GetComponent<Animator>();
        }
    }

    public IEnumerator RandomEncounter(Vector2 pos, int tipoIncontro)
    {
        if (tipoIncontro == 0)
        {
            bool combattimento = false;
            if (((int)pos.x >= 0 && (int)pos.x < 47) && ((int)pos.y >= 0 && (int)pos.y <= 18))
            {
                combattimento = true;
                stats.livelloNemici = 1;
                stats.nzona = 0;
            }
            else if (((int)pos.x >= 0 && (int)pos.x < 44) && ((int)pos.y >= 19 && (int)pos.y <= 38))
            {
                combattimento = true;
                stats.livelloNemici = 4;
                stats.nzona = 0;
            }
            else if (((int)pos.x >= 0 && (int)pos.x < 44) && ((int)pos.y >= 39 && (int)pos.y <= 64))
            {
                combattimento = true;
                stats.livelloNemici = 7;
                stats.nzona = 0;
            }
            else if (((int)pos.x >= 0 && (int)pos.x < 35) && ((int)pos.y >= 65 && (int)pos.y <= 99))
            {
                combattimento = true;
                stats.livelloNemici = 10;
                stats.nzona = 1;
            }
            else if (((int)pos.x >= 36 && (int)pos.x < 63) && ((int)pos.y >= 65 && (int)pos.y <= 99))
            {
                combattimento = true;
                stats.livelloNemici = 13;
                stats.nzona = 1;
            }
            else if (((int)pos.x >= 64 && (int)pos.x < 97) && ((int)pos.y >= 65 && (int)pos.y <= 99))
            {
                combattimento = true;
                stats.livelloNemici = 15;
                stats.nzona = 1;
            }
            else if (((int)pos.x >= 71 && (int)pos.x < 99) && ((int)pos.y >= 46 && (int)pos.y <= 65))
            {
                combattimento = true;
                stats.livelloNemici = 18;
                stats.nzona = 2;
            }
            else if (((int)pos.x >= 71 && (int)pos.x < 99) && ((int)pos.y >= 24 && (int)pos.y <= 47))
            {
                combattimento = true;
                stats.livelloNemici = 21;
                stats.nzona = 2;
            }
            else if (((int)pos.x >= 75 && (int)pos.x < 99) && ((int)pos.y >= 0 && (int)pos.y <= 25))
            {
                combattimento = true;
                stats.livelloNemici = 24;
                stats.nzona = 2;
            }
            else if (((int)pos.x >= 59 && (int)pos.x < 75) && ((int)pos.y >= 0 && (int)pos.y <= 25))
            {
                combattimento = true;
                stats.livelloNemici = 27;
                stats.nzona = 2;
            }
            else if (((int)pos.x >= 50 && (int)pos.x < 58) && ((int)pos.y >= 17 && (int)pos.y <= 41))
            {
                combattimento = true;
                stats.livelloNemici = 30;
                stats.nzona = 3;
            }
            if (combattimento)
            {
                stats.tipoIncontro = 0;
                GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(ingaggioBattaglia);
                Animator anim = cameraOBJ.GetComponent<Animator>();
                anim.SetTrigger("IncontroCasuale");

                yield return new WaitForSeconds(1.0f);
                anim.SetTrigger("FineIncontro");

                SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
                battleScene = SceneManager.GetSceneByName("Battle");
                SceneManager.SetActiveScene(battleScene);
            }
        }
        else
        {
            PlayerStatsControl stats = FindObjectOfType<PlayerStatsControl>();
            stats.tipoIncontro = tipoIncontro;
            GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(ingaggioBattaglia);
            Animator anim = cameraOBJ.GetComponent<Animator>();
            anim.SetTrigger("IncontroCasuale");

            yield return new WaitForSeconds(1.0f);
            anim.SetTrigger("FineIncontro");
            SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
            battleScene = SceneManager.GetSceneByName("Battle");
            SceneManager.SetActiveScene(battleScene);
        }
    }
}
