﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Potions : MonoBehaviour
{
    public bool oneTime = false;
    public bool isHpPotion;
    public bool isMpPotion;
    private PlayerStatsControl stats;
    public int costo;
    private Player player;
    private bool isDIalogueStart = false;

    public GameObject panelAvvisi;
    private PlayerMovement playerMov;

    public Sprite vitaGrande;
    public Sprite manaGrande;

    public AudioClip buyConfirm;
    private GameControl gc;

    void Start ()
    {
        Invoke("SetObjectToCell", 0.3f);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
        stats = FindObjectOfType<PlayerStatsControl>();
        gc = FindObjectOfType<GameControl>();
    }



    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().isSemiWall = true;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = 100 - (int)pos.y;
    }


    
    void Update ()
    {
        if (oneTime == true && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && !gc.incontroON)
        {
            if (isHpPotion == true && stats.soldi >= costo) // Al posto dello zero, verrà imposto come limite il prezzo della pozione
            {
                GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(buyConfirm);
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();
                stats.nPotionHealth++;
                //stats.soldi--;
                stats.soldi -= costo;
                ui.AggiornaPotion();
                ui.AggiornaAveri();
            }

            else if (isMpPotion == true && stats.soldi >= costo)
            {
                GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(buyConfirm);
                UiControlExploration ui = FindObjectOfType<UiControlExploration>();
                stats.nPotionMana++;
                stats.soldi -= costo;
                ui.AggiornaPotion();
                ui.AggiornaAveri();
            }
        }


    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name =="Player")
        {

            playerMov = col.gameObject.GetComponent<PlayerMovement>();
            panelAvvisi.SetActive(true);
            Image image = panelAvvisi.transform.Find("Image").GetComponent<Image>();
            Text text = panelAvvisi.transform.Find("Text").GetComponent<Text>();

            if (isHpPotion)
            {
                image.sprite = vitaGrande;
                text.text = "Vuoi acquistare ''Essenza della vita'' ? ";
            }
            if (isMpPotion)
            {
                image.sprite = manaGrande;
                text.text = "Vuoi acquistare ''Essenza del mana'' ? ";
            }
        }
    }
    


    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            oneTime = true;           
        }     
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        oneTime = false;
        panelAvvisi.SetActive(false);
    }
}
