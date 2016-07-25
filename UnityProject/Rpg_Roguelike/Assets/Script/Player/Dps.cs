using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Dps : Player
{
    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        this.stats.hpMax = playerstats.statsDps.hpMax;
        this.stats.hp = playerstats.statsDps.hp;
        this.stats.mp = playerstats.statsDps.mp;
        this.stats.mpMax = playerstats.statsDps.mpMax;

        this.stats.attMelee = playerstats.statsDps.attMelee;
        this.stats.attMagico = playerstats.statsDps.attMagico;
        this.stats.attDistanza = playerstats.statsDps.attDistanza;

        this.stats.difFisica = playerstats.statsDps.difFisica;
        this.stats.difMagica = playerstats.statsDps.difMagica;

        this.stats.evasione = playerstats.statsDps.evasione;
        this.stats.precisione = playerstats.statsDps.precisione;
        this.stats.velocita = playerstats.statsDps.precisione;

        for (int i = 0; i < playerstats.statsDps.abilitaSbloccate.Length; i++)
        {
            this.stats.abilitaSbloccate[i] = playerstats.statsDps.abilitaSbloccate[i];
        }

        UiController ui = FindObjectOfType<UiController>();
        ui.SetUiPlayer(this.gameObject);

    }

    public override void SubisciDanno(float danni)
    {
        int danniSubiti = Mathf.RoundToInt(((((danni / stats.difFisica) * 100) * (danni / 2)) / 100) * (Random.Range(1, 1.125f)));
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
        int raggio = 4;
        BattleGrid grid = FindObjectOfType<BattleGrid>();

        int _x = (int)pos.x;
        int _y = (int)pos.y;

        for (int i = (_x - raggio); i <= (_x + raggio); i++)
        {
            for (int y = (_y - raggio); y <= (_y + raggio); y++)
            {

                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > grid.width - 1)
                    continue;
                if (y > grid.height - 1)
                    continue;

                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (raggio))
                {
                    if (grid.cells[i, y].occupier != null)
                    {
                        if (grid.cells[i, y].occupier.CompareTag("Enemy"))
                            enemyDisp.Add(grid.cells[i, y].occupier);
                    }
                }
            }
            
        }
    }

    public override void SpawnAttackBox()
    {
        int raggio = 4;
        BattleGrid grid = FindObjectOfType<BattleGrid>();

        int _x = (int)pos.x;
        int _y = (int)pos.y;



        for (int i = (_x - raggio); i <= (_x + raggio); i++)
        {
            for (int y = (_y - raggio); y <= (_y + raggio); y++)
            {

                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > grid.width - 1)
                    continue;
                if (y > grid.height - 1)
                    continue;

                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (raggio))
                {
                    GameObject newAttack = Instantiate(checkAttack);
                    newAttack.transform.position = base.grid.cells[i, y].gameObject.transform.position;
                    checkboxAttack.Add(newAttack);
                }
            }

        }
    }

    public override void EndBattle()
    {
        PlayerStatsControl _stats = FindObjectOfType<PlayerStatsControl>();
        _stats.statsDps.hp = stats.hp;
    }

}
