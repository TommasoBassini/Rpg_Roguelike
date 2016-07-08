using UnityEngine;
using System.Collections;

public class Tank : Player
{
    public override void TakeStats()
    {
        PlayerStatsControl playerstats = FindObjectOfType<PlayerStatsControl>();

        stats.hpMax = playerstats.statsTank.hpMax;
        stats.hp = playerstats.statsTank.hp;
        stats.mpMax = playerstats.statsTank.mpMax;
        stats.mp = playerstats.statsTank.mp;

        stats.attMelee = playerstats.statsTank.attMelee;
        stats.attMagico = playerstats.statsTank.attMagico;
        stats.attDistanza = playerstats.statsTank.attDistanza;

        stats.difFisica = playerstats.statsTank.difFisica;
        stats.difMagica = playerstats.statsTank.difMagica;

        stats.evasione = playerstats.statsTank.evasione;
        stats.precisione = playerstats.statsTank.precisione;
        stats.velocita = playerstats.statsTank.precisione;
    }

    public override void SubisciDanno(int danni)
    {
        stats.hp = stats.hp - Mathf.RoundToInt(((((danni/stats.difFisica)*100) * (danni /2))/ 100) + (Random.Range(1,1.125f)));
        UiController ui = FindObjectOfType<UiController>();
        ui.AggiornaVita(stats.hpMax, stats.hp, uiInfo);
    }
}
