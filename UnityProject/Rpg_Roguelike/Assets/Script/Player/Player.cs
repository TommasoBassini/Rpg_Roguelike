﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Statistiche
{
    //Statistiche
    public int hpMax;
    public int hp;
    public int mpMax;
    public int mp;

    public int attMelee;
    public int attMagico;
    public int attDistanza;

    public int difFisica;
    public int difMagica;

    public int evasione;
    public int precisione;
    public int velocita;

    public bool[] abilitaSbloccate = new bool[5];
}

public abstract class Player : Character
{
    public Statistiche stats;
    public abstract void TakeStats();
    public abstract void EndBattle();
    public abstract void SubisciDanno(float danni);

    public abstract void SpawnAttackBox();
    public abstract void Attack(GameObject _enemy);
    public abstract void CheckAttack();
    public abstract void Death();
    public List<GameObject> enemyDisp = new List<GameObject>();
    public GameObject uiInfo;
    public GameObject checkAttack;
    public List<GameObject> checkboxAttack = new List<GameObject>();

    public Sprite image;
    public string nome;
    public GameObject spriteAttacco;
    public AudioClip attacco;

    // liste buff/debuff
    //BuffAttacco
    public List<int> nturnoBuffAttacco = new List<int>();
    public List<int> buffAttaccoMelee = new List<int>();
    public List<int> buffAttaccoRanged = new List<int>();
    public List<int> buffAttaccoMagico = new List<int>();

    //Protezione
    public int nTurnoProtezione = 0;


    //DebuffVeleno
    public int turniVeleno = 0;
    public int percVeleno;

    void DestroyButton()
    {
        foreach (Transform child in FindObjectOfType<UiController>().EnemyListPanel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void StartTurn()
    {
        if (nturnoBuffAttacco.Count != 0)
        {
            CheckBuffAttacco();
        }
        if(nTurnoProtezione > 0)
        {
            nTurnoProtezione--;
            //TODO aggiungere di cancellare l'effetto sprite qui
        }
        if (turniVeleno > 0)
        {
            CheckVeleno();
        }
    }

    void CheckBuffAttacco()
    {
        for (int i = nturnoBuffAttacco.Count - 1; i >= 0; i--)
        {
            nturnoBuffAttacco[i]--;
            if (nturnoBuffAttacco[i] == 0)
            {
                stats.attMelee -= buffAttaccoMelee[i];
                stats.attMagico -= buffAttaccoMagico[i];
                stats.attDistanza -= buffAttaccoRanged[i];

                buffAttaccoMelee.RemoveAt(i);
                buffAttaccoMagico.RemoveAt(i);
                buffAttaccoRanged.RemoveAt(i);

                nturnoBuffAttacco.RemoveAt(i);
            }
        }
    }

    public void SubisciDannoMagico(float danni)
    {
        int danniSubiti = Mathf.RoundToInt(((((danni / stats.difMagica) * 100) * (danni / 2)) / 100) * (Random.Range(1, 1.125f)));
        if (nTurnoProtezione > 0)
        {
            danniSubiti = (danniSubiti * 10) / 100;
            //TODO aggiungere di cancellare l'effetto sprite qui
            nTurnoProtezione = 0;
        }

        if (stats.hp - danniSubiti <= 0)
        {
            stats.hp = 0;
            CombatController cc = FindObjectOfType<CombatController>();
            List<int> n = new List<int>();
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = null;
            //cc.player.RemoveAll(item => item == enemy);
            for (int j = cc.turno + 1; j < cc.player.Count; j++)
            {
                if (cc.player[j] == this.gameObject)
                    n.Add(j);
            }
            for (int i = n.Count - 1; i >= 0; i--)
            {
                cc.player.RemoveAt(n[i]);
            }

            if (cc.CheckLose())
            {
                cc.Lose();
            }


            UiController ui1 = FindObjectOfType<UiController>();
            ui1.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
            ui1.DamageText(this.gameObject, danniSubiti, Color.red);
            Death();
            Destroy(this.gameObject);
        }
        else
            stats.hp = stats.hp - danniSubiti;
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
        ui.DamageText(this.gameObject, danniSubiti, Color.red);
    }

    void CheckVeleno()
    {
        UiController ui = FindObjectOfType<UiController>();

        int danno = Mathf.RoundToInt(((stats.hpMax * 5) / 100) * Random.Range(1.0f, 1.5f));
        stats.hp = stats.hp - danno;
        ui.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
        CombatController cc = FindObjectOfType<CombatController>();
        ui.DamageText(this.gameObject, danno, Color.red);
        if (stats.hp <= 0)
        {
            List<int> n = new List<int>();
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].isOccupied = false;
            base.grid.cells[(int)this.pos.x, (int)this.pos.y].occupier = null;
            //cc.player.RemoveAll(item => item == enemy);
            for (int j = cc.turno + 1; j < cc.player.Count; j++)
            {
                if (cc.player[j] == this.gameObject)
                    n.Add(j);
            }
            for (int i = n.Count - 1; i >= 0; i--)
            {
                cc.player.RemoveAt(n[i]);
            }

            if (!cc.CheckWinner())
            {
                cc.EndOfTurn();
            }
            else
                cc.Lose();
            Death();
            Destroy(this.gameObject);

        }

        turniVeleno--;
        if (turniVeleno == 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }

    public void MoveAbility()
    {
        isMovible = true;
        grid.AvailableMovement(pos, 20);
    }
}
