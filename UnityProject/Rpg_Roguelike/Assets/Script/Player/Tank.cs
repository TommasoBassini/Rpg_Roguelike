using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tank : Player
{
    public List<bool> abilityOn = new List<bool>();

    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        this.stats.hpMax = playerstats.statsTank.hpMax;
        this.stats.hp = playerstats.statsTank.hp;
        this.stats.mpMax = playerstats.statsTank.mpMax;
        this.stats.mp = playerstats.statsTank.mp;

        this.stats.attMelee = playerstats.statsTank.attMelee;
        this.stats.attMagico = playerstats.statsTank.attMagico;
        this.stats.attDistanza = playerstats.statsTank.attDistanza;

        this.stats.difFisica = playerstats.statsTank.difFisica;
        this.stats.difMagica = playerstats.statsTank.difMagica;

        this.stats.evasione = playerstats.statsTank.evasione;
        this.stats.precisione = playerstats.statsTank.precisione;
        this.stats.velocita = playerstats.statsTank.precisione;

        for (int i = 0; i < playerstats.statsTank.abilitaSbloccate.Length; i++)
        {
            this.stats.abilitaSbloccate[i] = playerstats.statsTank.abilitaSbloccate[i];
        }

        UiController ui = FindObjectOfType<UiController>();
        ui.SetUiPlayer(this.gameObject);
    }

    public override void SubisciDanno(float danni)
    {
        int danniSubiti = Mathf.RoundToInt(((((danni / stats.difFisica) * 100) * (danni / 2)) / 100) * (Random.Range(1, 1.125f)));
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

            if (!cc.CheckWinner())
            {
                cc.EndOfTurn();
            }
            else
                cc.Lose();

            UiController ui1 = FindObjectOfType<UiController>();
            ui1.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
            ui1.DamageText(this.gameObject, danniSubiti, Color.red);

            Destroy(this.gameObject);
        }
        else
            stats.hp = stats.hp - danniSubiti;
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
        ui.DamageText(this.gameObject, danniSubiti, Color.red);
    }

    public override void CheckAttack()
    {
        //classico controllo delle direzioni
        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        foreach (Vector2 dir in directions)
        {
            int new_x = (int)pos.x + (int)dir.x;
            int new_y = (int)pos.y + (int)dir.y;

            if (new_x < 0)
                continue;
            if (new_y < 0)
                continue;
            if (new_x > base.grid.width - 1)
                continue;
            if (new_y > base.grid.height - 1)
                continue;

            //se non esce dalla griglia e non è occupata aggiungo la posizione alla lista posDisp
            if (base.grid.cells[new_x, new_y].occupier != null)
            {
                if (base.grid.cells[new_x, new_y].occupier.CompareTag("Enemy"))
                    enemyDisp.Add(base.grid.cells[new_x, new_y].occupier);
            }
        }
    }

    public override void SpawnAttackBox()
    {
        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        foreach (Vector2 dir in directions)
        {
            int new_x = (int)pos.x + (int)dir.x;
            int new_y = (int)pos.y + (int)dir.y;

            if (new_x < 0)
                continue;
            if (new_y < 0)
                continue;
            if (new_x > base.grid.width - 1)
                continue;
            if (new_y > base.grid.height - 1)
                continue;


            GameObject newAttack = Instantiate(checkAttack);
            newAttack.transform.position = base.grid.cells[new_x, new_y].gameObject.transform.position;
            checkboxAttack.Add(newAttack);
        }
    }

    public override void EndBattle()
    {
        PlayerStatsControl _stats = FindObjectOfType<PlayerStatsControl>();
        _stats.statsTank.hp = stats.hp;
    }
}
