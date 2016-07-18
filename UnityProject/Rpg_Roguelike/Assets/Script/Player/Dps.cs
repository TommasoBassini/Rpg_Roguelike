using UnityEngine;
using System.Collections;



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
}
