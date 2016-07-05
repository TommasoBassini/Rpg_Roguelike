﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class CombatController : MonoBehaviour
{

    public List<GameObject> player;
    public List<float> tempo;
    public int turno = 0;

    private BattleGrid grid;
    public Image[] turnImage = new Image[8];

    public Sprite[] turnPortrait;

    void Start ()
    {
        grid = FindObjectOfType<BattleGrid>();
	}

    public void TurnOrder(List<float> _players, int n)
    {
        float temp;
        GameObject playerTemp;
        for (int i = 0; i < n-1; i++)
        {
            for (int k = 0; k < n - 1 - i; k++)
            {
                if (_players[k] > _players[k + 1])
                {
                    temp = _players[k];
                    playerTemp = player[k];

                    _players[k] = _players[k + 1];
                    player[k] = player[k + 1];

                    player[k + 1] = playerTemp;
                    _players[k + 1] = temp;
                }
            }
        }

        UpdateTurnPortrait();

    }

    void UpdateTurnPortrait()
    {
        for (int i = 0; i < turnImage.Length; i++)
        {
            if (player[i + turno].name == "Dps(Clone)")
            {
                turnImage[i].sprite = turnPortrait[0];
            }
            if (player[i + turno].name == "Mage(Clone)")
            {
                turnImage[i].sprite = turnPortrait[1];
            }
            if (player[i + turno].name == "Tank(Clone)")
            {
                turnImage[i].sprite = turnPortrait[2];
            }
            if (player[i + turno].name == "Enemy1(Clone)")
            {
                turnImage[i].sprite = turnPortrait[3];
            }
        }
    }

    public void ConfirmMovement()
    {
        Character character = player[turno].GetComponent<Character>();
        grid.ResetWalkableCell();
        character.isMovible = false;
        grid.cells[(int)character.pos.x, (int)character.pos.y].isOccupied = true;
        grid.cells[(int)character.pos.x, (int)character.pos.y].occupier = character.gameObject;
    }

    public void EndOfTurn()
    {
        UiController ui = FindObjectOfType<UiController>();
        turno++;
        UpdateTurnPortrait();
        if(player[turno].GetComponent<Enemy>() != null)
        {
            ui.UI.SetActive(false);
            player[turno].GetComponent<Enemy>().Ai();
        }
        else
            ui.UI.SetActive(true);
    }

    void TurnPrediction()
    {

    }
}
