﻿using UnityEngine;
using System.Collections;

public class CellObject : MonoBehaviour
{
    private PlayerMovement keys;
    public AudioClip dropKey;
       
	void Start ()
    {
        keys = FindObjectOfType<PlayerMovement>();
        Invoke("SetObjectToCell", 0.3f);       
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.clear;
    }

    void SetObjectToCell()
    {
        Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
        Grid grid = FindObjectOfType<Grid>();
        grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = this.gameObject;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Vector2 pos = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f);
            PlayerMovement player = coll.gameObject.GetComponent<PlayerMovement>();
            Grid grid = FindObjectOfType<Grid>();
            grid.cells[(int)pos.x, (int)pos.y].GetComponent<Cell>().cellObject = null;
            GameObject.Find("AudioManager").GetComponent<AudioSource>().PlayOneShot(dropKey);
            player.hasKey = true;
            keys.nKeys++;

            UiControlExploration ui = FindObjectOfType<UiControlExploration>();
            ui.AggiornaKey();
            Destroy(this.gameObject);
        }
    }
}




